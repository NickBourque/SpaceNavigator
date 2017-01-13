using System;
using System.Net.Sockets;

namespace ChatLib
{
    public class Client : SuperClientServer
    {
        /// <summary>
        /// This method overrides the parent class's abstract Connect method.
        /// It is used by the Client object to make a connection to the Server.
        /// </summary>
        /// <returns>True if a connection is successfully established, false if the connection fails.</returns>
        public override bool Connect() {

            Int32 port = 1234;              //The port on which the Client communicates.
            string server = "127.0.0.1";    //The IP address of the server the Client wishes to connect to.
            try
            {
                Client = new TcpClient(server, port);
                return true;
            }
            catch(SocketException sockEx)
            {
                return false;
            }
        }//end overridden method Connect

    }//end class Client

}//end namespace ChatLib
