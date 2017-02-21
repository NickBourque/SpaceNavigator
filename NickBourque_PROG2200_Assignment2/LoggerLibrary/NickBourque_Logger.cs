using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace LoggerLibrary
{
    public class NickBourque_Logger : ILoggingService
    {
        public void Log(string message)
        {
            NLog.Logger Logger = LogManager.GetCurrentClassLogger();
            LogEventInfo EventInfo = new LogEventInfo(LogLevel.Debug, "", message);
            Logger.Log(EventInfo);

        }
    }
    
}
