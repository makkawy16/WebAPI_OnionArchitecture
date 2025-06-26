using Contracts.RegisterServices;

namespace Contracts.Logger
{
    public interface ILoggerManager : ISingletone
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
