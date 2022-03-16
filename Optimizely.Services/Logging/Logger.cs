using Optimizely.Interfaces;
using System;

namespace Optimizely.Services.Logging
{
    public class Logger<T> : IProjectLogger<T> where T : class
    {
        public void LogCritical(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogDebug(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogError(string functionName, Exception ex, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogError(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogInformation(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string functionName, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
