using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary
{
    /// <summary>
    /// Contains the code to write the log file.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Writes to a log .txt file.
        /// </summary>
        /// <param name="message">The message to be logged (Sent/Received).</param>
        public void LogMessage(string message)
        {
            using (StreamWriter s = new StreamWriter("ChatLog.txt", true))
            {
                s.WriteLine(message);
            }
        }
    }
}
