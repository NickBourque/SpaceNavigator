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

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.I)
                        {
                            Console.Write(">>");
                            string message = Console.ReadLine();
                            server.SendMessage(message);
                        }

                    }

                    string serverIn = server.ReceiveMessage();

                    if (serverIn != null)
                    {
                        Console.WriteLine(serverIn);
                    }
                }//end while loop

            }
            else
            {
                Client client = new Client();
                bool conn = client.Connect();

                if (conn)
                {
                    Console.WriteLine("Connected to Server!");
                    client.OpenStream();

                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.Key == ConsoleKey.I)
                            {
                                Console.Write(">>");
                                string message = Console.ReadLine();
                                client.SendMessage(message);
                            }

                        }
                        
                        string clientIn = client.ReceiveMessage();

                        if (clientIn != null)
                        {
                            Console.WriteLine(clientIn);
                        }
                    }//end while loop
                }
                else {
                    Console.WriteLine("There was a problem connecting to the server... Please try again later.");
                    Console.Write("Press Enter to quit...");
                    Console.Read();
                }
            }


        }//end Main
    }//end class Program
}
