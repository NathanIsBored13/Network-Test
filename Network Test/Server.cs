using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Network_Test
{
    class Server
    {
        TcpListener tcpListener;
        TcpClient clientSocket;
        Thread t;
        public Server(int local_port)
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), local_port);
            tcpListener.Start();
            Console.WriteLine("SERVER: Server started");
            t = new Thread(new ThreadStart(AwaitCliantAsync));
            t.Start();
        }

        public void Shutdown()
        {
            t.Join();
        }

        private void AwaitCliantAsync()
        {
            clientSocket = tcpListener.AcceptTcpClient();
            Console.WriteLine("SERVER: Client connected");

            string fromClient;
            do
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[10025];
                networkStream.Read(bytesFrom);
                fromClient = Encoding.ASCII.GetString(bytesFrom);
                fromClient = fromClient.Substring(0, fromClient.LastIndexOf('$'));
                Console.WriteLine($"SERVER: {fromClient}");
            } while (fromClient != "exit");
        }
    }
}
