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
        private int ID;

        public int getID() => ID;
        public void setID(int id) { ID = id; }

        public TcpModel(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
            stream = tcpClient.GetStream();
            byteReceive = new byte[100];
        }

        public void sendData(string data)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byteSend = encoding.GetBytes(data);
            stream.Write(byteSend, 0, byteSend.Length);
            Console.WriteLine($"Send: {data}");
        }

        public string receiveData()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            stream.Read(byteReceive, 0, 100);
            string data = encoding.GetString(byteReceive);
            Console.WriteLine($"Receive: {data}");
            return data;
        }
    }
}
