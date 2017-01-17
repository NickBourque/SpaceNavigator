﻿using System;
using System.Net;
using System.Net.Sockets;

namespace ChatLib
{
    /// <summary>
    /// Server object accepts connections from a TCP Client. Extends Messenger.
    /// </summary>
    public class Server : Messenger
    {
        

        /// <summary>
        /// This method overrides the parent class's abstract Connect method.
        /// It is used by the Server object to make a connection to the Client.
        /// </summary>
        /// <returns>True when a TcpClient connects to the same port as the TcpListener</returns>
        public override bool Connect() {
            Int32 port = 1234;                                      //The port on which the Server communicates.
            IPAddress localHost = IPAddress.Parse("127.0.0.1");     //The IP address of the Server.
            TcpListener Listener = new TcpListener(localHost, port);            //A TcpListener object which acts as the chat server. The Client will connect to this listener.
            Listener.Start();

            while (true)
            {
                Client = Listener.AcceptTcpClient();
                return true;
            }
        }//end overridden method Connect

    }//end class Server

}//end namespace ChatLib
