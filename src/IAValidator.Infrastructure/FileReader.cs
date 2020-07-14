using IAValidator.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IAValidator.Infrastructure
{
    public class FileReader
    {
        IAppLogger<FileReader> _logger;
        public FileReader(IAppLogger<FileReader> appLogger)
        {
            _logger = appLogger;
        }

        public async Task<string> GetFileFromPath(string path)
        {
            var stream = new FileStream(path, FileMode.Open);
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);

            var created = File.GetCreationTime(path);

            _logger.LogInformation("Read file with {bytes} bytes from {path}", ms.Length, path);

            //return new SubpoenaFile(created, ms, path);

            return "";
        }
    }
}
