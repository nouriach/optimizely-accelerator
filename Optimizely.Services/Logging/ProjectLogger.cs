using Microsoft.Extensions.Logging;
using Optimizely.Interfaces;
using System;

namespace Optimizely.Services.Logging
{
    public class ProjectLogger<T> : IProjectLogger<T> where T : class
    {
        //private readonly ICorrelationIdService _correlationIdService;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ProjectLogger(ILogger<T> logger,
            ICorrelationIdService correlationIdService)
        {
            _logger = logger;
            //_correlationIdService = correlationIdService;
        }
        public void LogCritical(string functionName, string message, params object[] args)
        {
            _logger.LogCritical(GetLogMessage(functionName, message), args);
        }

        public void LogDebug(string functionName, string message, params object[] args)
        {
            _logger.LogDebug(GetLogMessage(functionName, message), args);
        }

        public void LogError(string functionName, Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, GetLogMessage(functionName, message), args);
        }

        public void LogError(string functionName, string message, params object[] args)
        {
            _logger.LogError(GetLogMessage(functionName, message), args);
        }

        public void LogInformation(string functionName, string message, params object[] args)
        {
            _logger.LogInformation(GetLogMessage(functionName, message), args);
        }

        public void LogTrace(string functionName, string message, params object[] args)
        {
            _logger.LogTrace(GetLogMessage(functionName, message), args);
        }

        public void LogWarning(string functionName, string message, params object[] args)
        {
            _logger.LogWarning(GetLogMessage(functionName, message), args);
        }
        private string GetLogMessage(string functionName, string message)
        {
            var objectName = $"Type: {typeof(T).FullName}";
            functionName = $"Function: {functionName}";
            message = $"Message: {message}";
            // var correlationId = _correlationIdService.GetCorrelationId();

            return $"ObjectName : {objectName} - FunctionName : {functionName} - Message : {message}";
        }
    }
}
