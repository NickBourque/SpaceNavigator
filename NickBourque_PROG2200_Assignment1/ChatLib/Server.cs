using System;
using System.Net;
using System.Net.Sockets;

namespace ChatLib
{
    public class Server : SuperClientServer
    {
        TcpListener listener = null;
        //TcpClient client = null;
        
        public override bool Connect() {
            Int32 port = 1234;
            IPAddress local = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(local, port);
            listener.Start();

            while (true)
            {
                client = listener.AcceptTcpClient();
                return true;
            }
        }//end overridden method Connect

    }//end class Server
}//end namespace ChatLib
