using IAValidator.Core.DTOs;
using IAValidator.Core.Interfaces;
using IAValidator.Core.Templates;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using IAValidator.Infrastructure;

namespace IAValidator.Core.Services
{
    public class ImportAgentXmlLoader : IImportAgentXmlLoader
    {
        private readonly IFileReader _reader;
        private readonly ISchemaValidator _schemaValidator;
        private readonly IAppLogger<ImportAgentXmlLoader> _logger;

        public ImportAgentXmlLoader(IAppLogger<ImportAgentXmlLoader> logger, IFileReader reader, ISchemaValidator schemaValidator)
        {
            _reader = reader;
            _schemaValidator = schemaValidator;
            _logger = logger;
        }

        public async Task<XDocument?> LoadImportAgentXml(string path, string schemaPath)
        {
            var xdoc = await GetImportAgentXml(path);

            if (xdoc == null)
            {
                return null;
            }

            var schema = await GetSchema(path);

            if (schema == null)
            {
                return null;
            }

            var schemaValidationResult = ValidateSchema(xdoc, schema);

            if (!schemaValidationResult.IsValid)
            {
                _logger.LogError("The following errors were detected while validating the supplied Import Agent file: {errors}", schemaValidationResult.Errors);

                return null;
            }

            return xdoc;
        }

        private async Task<XDocument> GetImportAgentXml(string path)
        {
            var result = await _reader.GetFileContentsFromPath(path);

            if (!result.IsSuccess)
            {
                _logger.LogError("The exception {exception} occurred while loading template definition file at path {path}", result.Exception!, path);
                return null!;
            }

            var xDoc = ConvertStringToXDocument(result.ContentString!);

            return xDoc;
        }

        private async Task<XmlSchemaSet> GetSchema(string path)
        {
            var schemaResult = await _reader.GetFileContentsFromPath(path);

            if (!schemaResult.IsSuccess)
            {
                _logger.LogError("The exception {exception} occurred while loading XSD file at path {path}", schemaResult.Exception!, path);
                return null!;
            }

            var schema = ConvertStringToSchema(schemaResult.ContentString!);

            return schema;
        }

        private SchemaValidationResult ValidateSchema(XDocument documentToValidate, XmlSchemaSet schemaToValidateAgainst)
        {
            var result = _schemaValidator.ValidateSchema(documentToValidate, schemaToValidateAgainst);

            return result;
        }

        private XmlSchemaSet ConvertStringToSchema(string contentString)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add(null, XmlReader.Create(new StringReader(contentString)));

            return schemas;
        }

        private XDocument ConvertStringToXDocument(string contentString)
        {
            XDocument doc;

            try
            {
                doc = new XDocument(XElement.Parse(contentString));
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception {ex} was thrown while parsing the supplied XML file", ex);

                return null!;
            }

            return doc;
        }


    }
}
