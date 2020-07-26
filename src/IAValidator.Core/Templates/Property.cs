using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Core.Templates
{
    public class Property
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string App { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public string ConditionError { get; set; }
        public string Currency { get; set; }
        public string Custom { get; set; }
        public bool IsRequired { get; set; }
    }
}
