using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionLogging
{
    public class Function
    {
        private readonly ILogger _logger;

        public Function(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function>();
        }

        [Function("Function")]
        public void Run([TimerTrigger("0/5 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogTrace($"LogTrace at: {DateTime.Now}");
            _logger.LogDebug($"LogDebug at: {DateTime.Now}");
            _logger.LogInformation($"LogInformation at: {DateTime.Now}");
            _logger.LogError($"LogError at: {DateTime.Now}");
            _logger.LogCritical($"LogCritical at: {DateTime.Now}");
        }
    }
}
