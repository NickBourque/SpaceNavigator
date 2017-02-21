using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

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
