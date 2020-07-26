using System.Threading.Tasks;
using System.Xml.Linq;

namespace IAValidator.Core.Interfaces
{
    public interface IImportAgentXmlLoader
    {
        Task<XDocument?> LoadImportAgentXml(string path, string schemaPath);
    }
}