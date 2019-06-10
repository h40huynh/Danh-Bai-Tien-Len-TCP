using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Root_Server
{
    public class TcpModelServer
    {
        private TcpListener tcpListener;

        public TcpModelServer(string ip, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void start()
        {
            tcpListener.Start();
        }

        public Socket listen()
        {
            return tcpListener.AcceptSocket();
        }
    }
}
