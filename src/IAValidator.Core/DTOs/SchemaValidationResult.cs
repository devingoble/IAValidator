using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Core.DTOs
{
    public class SchemaValidationResult
    {
        public bool IsValid 
        {
            get => Errors.Count() > 0;
        }

        public List<string> Errors { get; private set; } = new List<string>();

        public void AddError(string message)
        {
            Errors.Add(message);
        }
    }
}
