using System;

namespace CT.Utility.Interfaces
{
    public interface ICTLogger
    {
        void LogInfo(object message);
        void LogWarn(object message);
        void LogError(object message);
        void LogError(Exception exception);
    }
}
