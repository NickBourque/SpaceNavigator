using System;
using System.Net.Sockets;

namespace ChatLib
{
    public class Client : SuperClientServer
    {
        public override bool Connect() {

            Int32 port = 1234;
            string server = "127.0.0.1";
            try
            {
                client = new TcpClient(server, port);
                return true;
            }
            catch(SocketException sockEx)
            {
                return false;
            }
        }//end overridden method Connect

    }//end class Client

}//end namespace ChatLib
