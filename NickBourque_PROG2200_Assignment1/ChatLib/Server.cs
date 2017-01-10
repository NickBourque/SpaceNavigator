using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Server
    {
        
        public void connect() {
            Int32 port = 1234;
            IPAddress local = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(local, port);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
            }
        }//end method connect
        
    

    }//end class Server
}//end namespace ChatLib
