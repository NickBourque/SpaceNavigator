using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary
{
    public class Client
    {
        public TcpClient client;                //Holds the TcpClient connection.
        public NetworkStream Stream = null;     //Used to hold the NetworkStream object.
        Byte[] Data = null;                     //A byte array to hold byte data to be sent/received over the NetworkStream.

        public bool Connect()
        {
            Int32 port = 1234;              //The port on which the Client communicates.
            string server = "127.0.0.1";    //The IP address of the server the Client wishes to connect to.
            try
            {
                client = new TcpClient(server, port);
                return true;
            }
            catch (SocketException sockEx)
            {
                return false;
            }
        }//end method Connect




        /// <summary>
        /// Opens a NetworkStream via which messages can be sent and received.
        /// </summary>
        public void OpenStream()
        {
            Stream = client.GetStream();

        }//end method OpenStream




        /// <summary>
        /// Converts message text to a byte array and writes it to the stream.
        /// </summary>
        /// <param name="message">The actual message text typed by the user (before it is converted).</param>
        public void SendMessage(string message)
        {
            Data = System.Text.Encoding.ASCII.GetBytes(message);
            Stream.Write(Data, 0, Data.Length);
        }//end method SendMessage





        /// <summary>
        /// If incoming data is available on the NetworkStream, the data is read into a byte array, 
        /// encoded as a string and returned.
        /// </summary>
        /// <returns>A string of the received message, or null if no message is received.</returns>
        public string ReceiveMessage()
        {
            try
            {
                Data = new Byte[256];
                string receivedMessage = String.Empty;
                if (Stream.DataAvailable)
                {
                    Int32 bytes = Stream.Read(Data, 0, Data.Length);
                    receivedMessage = System.Text.Encoding.ASCII.GetString(Data, 0, bytes);
                    return receivedMessage;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }//end method ReceiveMessage
    }//end class Client
}//end namespace ChatLibrary
