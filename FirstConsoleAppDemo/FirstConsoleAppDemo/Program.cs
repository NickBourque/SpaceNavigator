using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello from C#");

            //Console.Write("Enter your name: ");
            //string input = Console.ReadLine();
            //Console.WriteLine(String.Format("Hello {0}!", input));

            Console.WriteLine("Hit any key...");


            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.I)
                    {
                        Console.WriteLine("You pressed the I key");
                    }
                    else
                    {
                        Console.WriteLine("You didn't press the I key.");
                    }

                }
                Console.WriteLine("Listening...");
                Thread.Sleep(200);
            }

           

            Console.Read();//stops console window from closing
        }
    }
}
