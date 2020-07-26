using IAValidator.Core.DTOs;

using System.Threading.Tasks;

namespace IAValidator.Infrastructure
{
    public interface IFileReader
    {
        Task<FileResult> GetFileContentsFromPath(string path);
    }
}