using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;

namespace Root_Server
{
    class Program
    {
        private List<TcpModel> tcps = new List<TcpModel>();
        private TcpModelServer tcpServer;
        private int numOfPlayer = 0;

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
            int res = 0;
            if ((num / 4) % 2 == 0)
                res = 8080;
            else
                res = 9090;
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
            try
            {
                TcpModel tcp = obj as TcpModel;
                while (true)
                {
                    string data = tcp.tcpClient.receiveData();
                    tcp.player.sendData(data);
                }
            }
            catch
            {

            }
        }
    }
}
