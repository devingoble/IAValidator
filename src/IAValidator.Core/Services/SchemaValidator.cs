using IAValidator.Core.DTOs;
using IAValidator.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace IAValidator.Core.Services
{
    public class SchemaValidator : ISchemaValidator
    {
        public SchemaValidationResult ValidateSchema(XDocument docToValidate, XmlSchemaSet schemaToValidateAgainst)
        {
            var result = new SchemaValidationResult();

            docToValidate.Validate(schemaToValidateAgainst, (o, e) =>
            {
                result.AddError(e.Message);
            });

            return result;
        }
    }
}
