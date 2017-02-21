using System.Configuration;
using System.IO;

namespace LoggerLibrary
{
    /// <summary>
    /// Contains the code to write the log file.
    /// </summary>
    public class Logger : ILoggingService
    {
        /// <summary>
        /// Writes to a log .txt file.
        /// </summary>
        /// <param name="message">The message to be logged (Sent/Received).</param>
        public void Log(string message)
        {
            using (StreamWriter s = new StreamWriter(ConfigurationManager.AppSettings["LogPath"], true))
            {
                s.WriteLine(message);
            }
        }
    }
}
