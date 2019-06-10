using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Root_Server
{
    class TcpModel
    {
        public Player player;
        public TcpModelClient tcpClient;

        public TcpModel(Player p, TcpModelClient c)
        {
            player = p;
            tcpClient = c;
        }
    }
}
