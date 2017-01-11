using System;
using System.Net.Sockets;

namespace ChatLib
{
    public abstract class SuperClientServer
    {
        public NetworkStream stream = null;
        public TcpClient client = null;
        Byte[] data = null;
        
        /// <summary>
        /// Abstract Connect method. Overridden in Client and Server subclasses.
        /// </summary>
        /// <returns>Boolean identifying whether a connection has been established.</returns>
        public abstract bool Connect();
 
        /// <summary>
        /// Opens a NetworkStream via which messages can be sent and received.
        /// </summary>
        public void OpenStream()
        {
            stream = client.GetStream();
        }//end method OpenStream

        /// <summary>
        /// Converts message text to a byte array and writes it to the stream.
        /// </summary>
        /// <param name="message">The actual message text typed by the user (before it is converted).</param>
        public void SendMessage(string message)
        {
            data = System.Text.Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }//end method SendMessage

        public string ReceiveMessage()
        {
            try
            {
                data = new Byte[256];
                string receivedMessage = String.Empty;
                if (stream.DataAvailable)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    receivedMessage = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    return receivedMessage;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }//end method ReceiveMessage

    }//end super class SuperClientServer

}//end namespace ChatLib
