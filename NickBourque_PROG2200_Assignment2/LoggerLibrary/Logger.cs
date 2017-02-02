using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary
{
    public class Logger
    {

        public void LogMessage(string message)
        {
            using (StreamWriter s = new StreamWriter("C:/Users/NSCC Student/Desktop/ChatLog.txt"))
            {
                s.WriteLine(message + s.NewLine);
            }
        }


    }
}
