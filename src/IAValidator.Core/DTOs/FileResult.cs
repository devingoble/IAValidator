using System;
using System.Collections.Generic;
using System.Text;

namespace IAValidator.Core.DTOs
{
    public class FileResult
    {
        public string? ContentString { get; private set; }
        public bool IsSuccess { get; private set; }
        public Exception? Exception { get; private set; }

        public void SetContent(string content)
        {
            ContentString = content;
            IsSuccess = true;
        }

        public void SetError(Exception exception)
        {
            Exception = exception;
            IsSuccess = false;
        }
    }
}
