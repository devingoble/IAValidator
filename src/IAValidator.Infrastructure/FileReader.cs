using IAValidator.Core.DTOs;
using IAValidator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Infrastructure
{
    public class FileReader : IFileReader
    {
        IAppLogger<FileReader> _logger;
        public FileReader(IAppLogger<FileReader> appLogger)
        {
            _logger = appLogger;
        }

        private async Task<string> GetFileFromPath(string path)
        {
            var stream = new FileStream(path, FileMode.Open);
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();

            _logger.LogInformation("Read file with {bytes} bytes from {path}", stream.Length, path);

            return content;
        }

        public async Task<FileResult> GetFileContentsFromPath(string path)
        {
            var result = new FileResult();
            string content;

            try
            {
                content = await GetFileFromPath(path);
                result.SetContent(content);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
                _logger.LogError(result.Exception!, "Could not import file from path {path}", path);
            }

            if (result.IsSuccess)
            {
                if (string.IsNullOrWhiteSpace(result.ContentString))
                {
                    result.SetError(new Exception("The supplied file was empty"));
                }
            }

            return result;
        }
    }
}
