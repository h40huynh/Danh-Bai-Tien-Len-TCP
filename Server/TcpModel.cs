using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class TcpModel
    {
        private TcpListener tcpListener;

        public TcpModel(string ip, int port)
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
