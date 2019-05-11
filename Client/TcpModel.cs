using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class TcpModel
    {
        private TcpClient tcpClient;
        private Stream stream;
        private byte[] byteReceive;

        public TcpModel(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
            stream = tcpClient.GetStream();
            byteReceive = new byte[100];
        }

        public void sendData(string data)
        {
            byte[] byteSend = Encoding.ASCII.GetBytes(data);
            stream.Write(byteSend, 0, byteSend.Length);
        }

        public string receiveData()
        {
            stream.Read(byteReceive, 0, 100);
            return Encoding.ASCII.GetString(byteReceive);
        }
    }
}
