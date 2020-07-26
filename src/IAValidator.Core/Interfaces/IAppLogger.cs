﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IAValidator.Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogInformation(Exception exception, string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogWarning(Exception exception, string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
    }
}
