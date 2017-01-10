using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLib;

namespace ChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "-server")
            {
                Server server = new Server();
                Console.WriteLine("Waiting for client connection...");
                server.Connect();
                Console.WriteLine("Client Connected!");
                server.OpenStream();
                Console.Read();
            }
            else
            {
                Client client = new Client();
                client.Connect();
                client.OpenStream();
                Console.Read();
            }


        }//end Main
    }//end class Program
}
