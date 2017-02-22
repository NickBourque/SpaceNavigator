using System;
using System.Net.Sockets;
using LoggerLibrary;
//using LogLib;

namespace ChatLibrary
{

    /// <summary>
    /// A client that can connect to a TcpListener, send and receive messages.
    /// </summary>
    public class Client
    {

        public Client(ILoggingService Logger)
        {
            this.Logger = Logger;
        }

        
        public event MessageReceivedEventHandler MessageReceived;   //Event fires when a new message is received.

        bool Listening;                         //Determines if the client should keep listening for incoming messages.
        TcpClient client;                       //Holds the TcpClient connection.
        NetworkStream Stream = null;            //Used to hold the NetworkStream object.
        Byte[] Data = null;                     //A byte array to hold byte data to be sent/received over the NetworkStream.
        ILoggingService Logger;// = new Logger();


        /// <summary>
        /// Connects to a TcpListener
        /// </summary>
        /// <returns>Boolean; true if connect success, false if connect fails.</returns>
        public bool Connect()
        {
            Int32 port = 1234;                  //The port on which the Client communicates.
            string server = "127.0.0.1";        //The IP address of the server the Client wishes to connect to.
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
        /// Closes the TcpClient connection to the TcpListener.
        /// </summary>
        /// <returns>Boolean; false if disconnected, true if fails to disconnect (i.e. connected = true).</returns>
        public bool Disconnect()
        {
            try
            {
                Listening = false;
                client.Close();
                return false;
            }
            catch(NullReferenceException ex)
            {
                return true;
            }
        }//end method Disconnect
        

        /// <summary>
        /// Opens a NetworkStream via which messages can be sent and received.
        /// </summary>
        public void OpenStream()
        {
            Stream = client.GetStream();
        }//end method OpenStream
        

        /// <summary>
        /// Converts message text to a byte array and writes it to the stream, and logs the message.
        /// </summary>
        /// <param name="message">The actual message text typed by the user (before it is converted).</param>
        public void SendMessage(string message)
        {
            Data = System.Text.Encoding.ASCII.GetBytes(message);
            Stream.Write(Data, 0, Data.Length);

            Logger.Log("("+DateTime.Now + ") Sent: " + message);

        }//end method SendMessage


        /// <summary>
        /// If incoming data is available on the NetworkStream, the data is read into a byte array, 
        /// encoded as a string and returned. Also logs the message.
        /// </summary>
        public void ReceiveMessage()
        {
            try
            {
                Data = new Byte[256];
                string receivedMessage = String.Empty;
                if (Stream.DataAvailable)
                {
                    Int32 bytes = Stream.Read(Data, 0, Data.Length);
                    receivedMessage = System.Text.Encoding.ASCII.GetString(Data, 0, bytes);

                    Logger.Log("(" + DateTime.Now + ") Received: " + receivedMessage);

                    MessageReceived(this, new MessageReceivedEventArgs(receivedMessage));
                }
            }
            catch (Exception ex)
            {
                
            }
        }//end method ReceiveMessage


        /// <summary>
        /// Listening loop to listen for messages.
        /// </summary>
        public void ListenForMessages()
        {
            Listening = true;

            while(Listening)
            {
                ReceiveMessage();
            }
        }//end method ListenForMessages

    }//end class Client
}//end namespace ChatLibrary
