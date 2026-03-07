namespace AddressBookAPI.Services.Logging
{
    public class ApplicationLogger : IApplicationLogger
    {
        private readonly ILogger<ApplicationLogger> _logger;

        public ApplicationLogger(ILogger<ApplicationLogger> logger)
        {
            _logger = logger;
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation($"[INFO] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogError(string message, Exception? ex = null)
        {
            if (ex != null)
                _logger.LogError($"[ERROR] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message} - {ex.Message}");
            else
                _logger.LogError($"[ERROR] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning($"[WARNING] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}
