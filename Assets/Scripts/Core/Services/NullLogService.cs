using InCheck.Core.Interfaces;

namespace InCheck.Core.Services
{
    public sealed class NullLogService : ILogService
    {
        public void Log(string message)
        {
        }

        public void Warn(string message)
        {
        }

        public void Error(string message)
        {
        }
    }
}
