using System;
using ChatLib;
using System.IO;

namespace ChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger chatter;
            bool connected;
            string errorMessage = string.Empty;

            if (args.Length > 0 && args[0] == "-server")
            {
                chatter = new Server();
                Console.Write("Waiting for client connection...");
                connected = chatter.Connect(out errorMessage);
                Console.WriteLine("Client Connected!");
                chatter.OpenStream();
            }
            else
            {
                chatter = new Client();
                connected = chatter.Connect(out errorMessage);

                if (connected)
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

            Console.WriteLine("Press the \"i\" key to start typing a message.");
            Console.WriteLine("Enter \"quit\" to exit.\n");
            Console.WriteLine("-----------------------\n");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.I)
                    {
                        Console.Write(">>");
                        string outgoingMessage = Console.ReadLine();
                        if (outgoingMessage.ToLower() == "quit")
                        {
                            outgoingMessage = "----->Your chat partner has left the session.";

                            try
                            {
                                chatter.SendMessage(outgoingMessage);
                            }
                            catch (IOException ioEx)
                            {
                                Environment.Exit(0);
                            }
                            
                            Environment.Exit(0);
                        }
                        try
                        {
                            chatter.SendMessage(outgoingMessage);
                        }
                        catch(IOException ioEx)
                        {
                            Console.WriteLine("Connection lost! Press Enter to exit.");
                            Console.Read();
                            Environment.Exit(0);
                        }
                        
                    }

                }

                string incomingMessage = chatter.ReceiveMessage();

                if (incomingMessage != null)
                {
                    Console.WriteLine(incomingMessage);
                }
            }//end while loop
                
        }//end Main

    }//end class Program
}
