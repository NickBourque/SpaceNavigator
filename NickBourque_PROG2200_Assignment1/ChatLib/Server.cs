using System;
using System.Net;
using System.Net.Sockets;

namespace ChatLib
{
    public class Server : SuperClientServer
    {
        TcpListener listener = null;

        /// <summary>
        /// This method overrides the parent class's abstract Connect method.
        /// It is used by the Server object to make a connection to the Client.
        /// </summary>
        /// <returns>True when a TcpClient connects to the same port as the TcpListener</returns>
        public override bool Connect() {
            Int32 port = 1234;
            IPAddress localHost = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(localHost, port);
            listener.Start();

            while (true)
            {
                client = listener.AcceptTcpClient();
                return true;
            }
        }//end overridden method Connect

    }//end class Server

}//end namespace ChatLib
