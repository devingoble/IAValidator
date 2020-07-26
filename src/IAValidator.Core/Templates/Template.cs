using IAValidator.Core.TemplateS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Core.Templates
{
    public class Template
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string App { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TemplateProperty> Properties { get; set; } = new List<TemplateProperty>();
    }
}
