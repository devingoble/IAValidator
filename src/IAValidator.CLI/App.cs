using IAValidator.Core.Interfaces;

using MediatR;

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
        private readonly IMediator _mediator;

        public App(IAppLogger<App> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Run(string iaXmlPath, string templateXmlPath)
        {
            _logger.LogInformation("Validating Import Agent XML from {iaXmlPath} using template XML from {templateXmlPath}", iaXmlPath, templateXmlPath);


        }
    }
}
