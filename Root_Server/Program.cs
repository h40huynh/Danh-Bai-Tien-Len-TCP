using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Root_Server
{
    class Program
    {
        private List<TcpModel> tcps = new List<TcpModel>();
        private TcpModelServer tcpServer;
        private int numOfPlayer = 0;
        private bool isRunning1 = true, isRunning2 = true;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.startRootServer();
        }

        public void startRootServer()
        {
            tcpServer = new TcpModelServer("127.0.0.1", 13000);
            tcpServer.start();
            Console.WriteLine("Start Root Server");
            Thread thread = new Thread(listenThread);
            thread.Start();
        }

        private int choosePort(int num)
        {
            if (num % 4 == 0)
            {
                if (isRunning1 == false && reConnect("127.0.0.1", 8080) == 1)
                    isRunning1 = true;
                if (isRunning2 == false && reConnect("127.0.0.1", 9090) == 1)
                    isRunning2 = true;
            }

            int res = 0;
            if (isRunning1 && (num / 4) % 2 == 0)
                res = 8080;
            else if (isRunning2)
                res = 9090;
            else if (isRunning1)
                res = 8080;
            Console.WriteLine($"Port = {res}");
            return res;
        }

        private void listenThread()
        {
            while (true)
            {
                Socket socket = tcpServer.listen();
                Player player = new Player(socket);

                numOfPlayer++;
                Console.WriteLine("Accept socket from user ");
                int port = choosePort(numOfPlayer - 1);
                TcpModelClient client = new TcpModelClient("127.0.0.1", port);

                TcpModel newTcp = new TcpModel(player, client);
                tcps.Add(newTcp);

                Thread thread1 = new Thread(reciveClientData);
                thread1.Start(newTcp);

                Thread thread2 = new Thread(receiveServerData);
                thread2.Start(newTcp);
            }
        }

        private void reciveClientData(object obj)
        {
            TcpModel tcp = obj as TcpModel;
            try
            {
                while (true)
                {
                    string data = tcp.player.receiveData();
                    tcp.tcpClient.sendData(data);
                }
            }
            catch (Exception)
            {
                tcp.player.closeConnection();                
            }
        }

        private void receiveServerData(object obj)
        {
            TcpModel tcp = obj as TcpModel;
            try
            {
                while (true)
                {
                    string data = tcp.tcpClient.receiveData();
                    tcp.player.sendData(data);
                }
            }
            catch
            {
                if (tcp.tcpClient.port == 8080)
                {
                    isRunning1 = false;
                    tcp.player.sendData("Error");
                    tcp.player.closeConnection();
                }
                else
                {
                    isRunning2 = false;
                    tcp.player.sendData("Error");
                    tcp.player.closeConnection();
                }
            }
        }

        private int reConnect(string ip, int port)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);
                Stream stream = tcpClient.GetStream();
                return 1;
            }
            catch
            {
                return -1;
            }

        }
    }
}
