using IAValidator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IAValidator.CLI
{
    public class App
    {
        private readonly IAppLogger<App> _logger;

        public App(IAppLogger<App> logger)
        {
            _logger = logger;
        }

        public async Task Run(string iaXmlPath, string templateXmlPath)
        {
            _logger.LogInformation("Validating Import Agent XML from {iaXmlPath} using template XML from {templateXmlPath}", iaXmlPath, templateXmlPath);           }
    }
}
