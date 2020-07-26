using IAValidator.Core.Interfaces;
using IAValidator.Core.Templates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Core.Services
{
    public class TemplateDeserializer
    {
        private readonly IAppLogger<TemplateDeserializer> _logger;

        public TemplateDeserializer(IAppLogger<TemplateDeserializer> logger)
        {
            _logger = logger;
        }

        public List<Template> LoadTemplates(string templateString)
        {

        }
    }
}
