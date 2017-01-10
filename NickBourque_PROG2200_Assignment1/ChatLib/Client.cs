﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Client
    {
        TcpClient client = null;
        NetworkStream stream = null;
        Byte[] data = null;
        //string message = null;

        public bool Connect() {

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
        }//end method Connect

        public void OpenStream()
        {
            

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();

            stream = client.GetStream();

        }//end method OpenStream

        public void SendMessage(string message)
        {
            
            data = System.Text.Encoding.ASCII.GetBytes(message);

            stream.Write(data, 0, data.Length);
            
        }


        public string ReceiveMessage()
        {
            try
            {
                data = new Byte[256];
                string receivedData = String.Empty;
                if (stream.DataAvailable)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    receivedData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    return receivedData;
                }
            }
            catch(Exception ex) { return null; }
            return null;
            
        }

        ////// Send the message to the connected TcpServer. 
        ////stream.Write(data, 0, data.Length);

        ////    Console.WriteLine("Sent: {0}", message);

        //    // Receive the TcpServer.response.

        //    // Buffer to store the response bytes.
        //    data = new Byte[256];

        //    // String to store the response ASCII representation.
        //    String responseData = String.Empty;

        //// Read the first batch of the TcpServer response bytes.
        //Int32 bytes = stream.Read(data, 0, data.Length);
        //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //    Console.WriteLine("Received: {0}", responseData);

        //    // Close everything.
        //    stream.Close();
        //    //client.Close();
        
        
    }
}
