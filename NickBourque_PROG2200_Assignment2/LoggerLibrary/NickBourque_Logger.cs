using NLog;

namespace LoggerLibrary
{

    /// <summary>
    /// Logger using NLog
    /// </summary>
    public class NickBourque_Logger : ILoggingService
    {
        /// <summary>
        /// Logs messages
        /// </summary>
        /// <param name="message">The message being logged.</param>
        public void Log(string message)
        {
            NLog.Logger Logger = LogManager.GetCurrentClassLogger();
            LogEventInfo EventInfo = new LogEventInfo(LogLevel.Debug, "", message);
            Logger.Log(EventInfo);

        }
    }
    
}
