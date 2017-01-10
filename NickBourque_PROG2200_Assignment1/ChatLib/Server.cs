using System;
using System.Net;
using System.Net.Sockets;

namespace ChatLib
{
    public class Server
    {
        TcpListener listener = null;
        TcpClient client = null;
        NetworkStream stream = null;
        Byte[] data = null;
        
        public void Connect() {
            Int32 port = 1234;
            IPAddress local = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(local, port);
            listener.Start();

            while (true)
            {
                client = listener.AcceptTcpClient();
                return;
            }
        }//end method Connect

        public void OpenStream() {

                // Get a stream object for reading and writing
                stream = client.GetStream();

        }//end method OpenStream


        public void SendMessage(string message)
        {
            if (message == "quit") { Environment.Exit(0); }

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
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }




    }//end class Server
}//end namespace ChatLib
