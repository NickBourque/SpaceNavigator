using System;
using System.Net.Sockets;

namespace ChatLib
{
    public abstract class SuperClientServer
    {
        public NetworkStream stream = null;
        public TcpClient client = null;
        Byte[] data = null;
        
        public abstract bool Connect();
 
        public void OpenStream()
        {
            stream = client.GetStream();
        }//end method OpenStream

        public void SendMessage(string message)
        {
            if (message.ToLower() == "quit")
            {
                Environment.Exit(0);
            }

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
