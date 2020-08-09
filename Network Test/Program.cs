using System;
using System.Net.Sockets;
using System.Threading;

namespace Network_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("entrer local port to host server on: ");
            Server s = new Server(int.Parse(Console.ReadLine()));
            Console.WriteLine("enter target port to connect to: ");
            Client c = new Client(int.Parse(Console.ReadLine()));

            string str;
            do
            {
                str = Console.ReadLine();
                c.SendString(str);
            } while (str != "exit");

            s.Shutdown();
        }
    }
}
