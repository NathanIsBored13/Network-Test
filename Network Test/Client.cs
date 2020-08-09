using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network_Test
{
    class Client
    {
        NetworkStream networkStream;

        public Client(int target_port)
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", target_port);
            networkStream = tcpClient.GetStream();
            Console.WriteLine("CLIENT - client connected");
        }

        public void SendString(string msg)
        {
            byte[] outstream = Encoding.ASCII.GetBytes($"{msg}$");
            networkStream.Write(outstream, 0, outstream.Length);
            networkStream.Flush();
        }
    }
}