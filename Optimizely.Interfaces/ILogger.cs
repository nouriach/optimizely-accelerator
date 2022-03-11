using System;

namespace Optimizely.Interfaces
{
    public interface ILogger
    {
        void LogInformation(string functionName, string message, params object[] args);
        void LogCritical(string functionName, string message, params object[] args);
        void LogDebug(string functionName, string message, params object[] args);
        void LogError(string functionName, Exception ex, string message, params object[] args);
        void LogError(string functionName, string message, params object[] args);
        void LogTrace(string functionName, string message, params object[] args);
        void LogWarning(string functionName, string message, params object[] args);
    }

    public interface ILogger<T> : ILogger where T : class
    {
    }
}
