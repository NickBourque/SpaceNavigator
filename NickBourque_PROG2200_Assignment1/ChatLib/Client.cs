using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Client
    {
        public void connect() {

            Int32 port = 1234;
            String server = "127.0.0.1";

            TcpClient client = new TcpClient(server, port);
        }
        
    }
}
