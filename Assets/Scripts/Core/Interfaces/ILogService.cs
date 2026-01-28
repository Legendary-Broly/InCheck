namespace InCheck.Core.Interfaces
{
    public interface ILogService
    {
        void Log(string message);
        void Warn(string message);
        void Error(string message);
    }
}
