namespace AddressBookAPI.Services.Logging
{
    public interface IApplicationLogger
    {
        void LogInfo(string message);
        void LogError(string message, Exception? ex = null);
        void LogWarning(string message);
    }
}
