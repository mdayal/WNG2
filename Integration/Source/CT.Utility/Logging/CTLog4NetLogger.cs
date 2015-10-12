using System;
using System.IO;
using CT.Utility.Interfaces;
using CT.log4net;
using CT.log4net.Config;

namespace CT.Utility.Logging
{
    public class CTLog4NetLogger : ICTLogger
    {
        private readonly ILog _logger;
        public CTLog4NetLogger(string configFilePath, string loggerName = "")
        {
            var fileInfo = new FileInfo(configFilePath);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
            _logger = string.IsNullOrEmpty(loggerName) ? LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType) : LogManager.GetLogger(loggerName);     
        }

        public void LogInfo(object message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        public void LogWarn(object message)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message);
        }

        public void LogError(object message)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(message);
        }

        void ICTLogger.LogError(Exception exception)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(exception.Message, exception);
        }
    }
}
