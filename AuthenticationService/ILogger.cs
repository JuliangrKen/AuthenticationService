namespace AuthenticationService
{
    public interface ILogger
    {
        void WriteEvent(string message);
        void WriteError(string message);
    }
}
