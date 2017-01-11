using System;
using ChatLib;

namespace ChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperClientServer chatter;
            bool conn;

            if (args.Length > 0 && args[0] == "-server")
            {
                chatter = new Server();
                Console.WriteLine("Waiting for client connection...");
                conn = chatter.Connect();
                Console.WriteLine("Client Connected!");
                chatter.OpenStream();
            }
            else
            {
                chatter = new Client();
                conn = chatter.Connect();

                if (conn)
                {
                    Console.WriteLine("Connected to Server!");
                    chatter.OpenStream();
                }
                else
                {
                    Console.WriteLine("There was a problem connecting to the server... Please try again later.");
                    Console.Write("Press Enter to quit...");
                    Console.Read();
                    Environment.Exit(0);
                }

            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.I)
                    {
                        Console.Write(">>");
                        string message = Console.ReadLine();
                        chatter.SendMessage(message);
                    }

                }

                string msgIn = chatter.ReceiveMessage();

                if (msgIn != null)
                {
                    Console.WriteLine(msgIn);
                }
            }//end while loop
                
        }//end Main

    }//end class Program
}
