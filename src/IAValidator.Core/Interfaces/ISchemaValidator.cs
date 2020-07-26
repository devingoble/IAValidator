using IAValidator.Core.DTOs;

using System.Xml.Linq;
using System.Xml.Schema;

namespace IAValidator.Core.Interfaces
{
    public interface ISchemaValidator
    {
        SchemaValidationResult ValidateSchema(XDocument docToValidate, XmlSchemaSet schemaToValidateAgainst);
    }
}