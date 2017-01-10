using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Server
    {
        TcpListener listener = null;
        TcpClient client = null;
        NetworkStream stream = null;
        string data = null;
        Byte[] bytes = new Byte[256];


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
            while (true)
            {
                //data = null;

                // Get a stream object for reading and writing
                stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    //--------------------

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }
            }

        }//end method OpenStream
        
    

    }//end class Server
}//end namespace ChatLib
