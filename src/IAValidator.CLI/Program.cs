using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using IAValidator.Core.Interfaces;
using IAValidator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace IAValidator.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var xmlPathOption = new Option<string>("--xml-file", "Takes the path to an Import Agent compatible XML file").LegalFilePathsOnly();
            xmlPathOption.AddAlias("-x");
            xmlPathOption.Required = true;

            var templateDefinitionPathOption = new Option<string>(
                alias: "--template-xml",
                description: "Takes a path to the template definition XML file that can be exported from the Laserfiche Administration Console"
                ).LegalFilePathsOnly();
            templateDefinitionPathOption.AddAlias("-t");
            templateDefinitionPathOption.Required = true;

            var logToFilePathOption = new Option<string>(
                alias: "--log-file",
                description: "Optionally log to the specified file",
                getDefaultValue: () => ""
                ).LegalFilePathsOnly();
            logToFilePathOption.AddAlias("-l");

            var rootCommand = new RootCommand("Import Agent XML Validator")
            {
                xmlPathOption,
                templateDefinitionPathOption,
                logToFilePathOption
            };

            rootCommand.Handler = CommandHandler.Create<string, string, string>(
                async (xmlFile, templateXml, logFile) =>
            {
                ConfigureLogging(logFile, serviceProvider.GetRequiredService<ILoggerFactory>());

                await serviceProvider.GetService<App>().Run(xmlFile, templateXml);

                return 0;
            });

            await rootCommand.InvokeAsync(args);
        }

        private static void ConfigureLogging(string logFilePath, ILoggerFactory loggerFactory)
        {
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(logFilePath)
                .CreateLogger();
            }

            loggerFactory.AddSerilog();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });
            services.AddTransient<App>();
        }
    }
}
