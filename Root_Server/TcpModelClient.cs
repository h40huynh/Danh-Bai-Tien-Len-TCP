﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Root_Server
{
    public class TcpModelClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private int ID;
        public int port;

        public int getID() => ID;
        public void setID(int id) { ID = id; }
        private ASCIIEncoding encoding;

        public TcpModelClient(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
            this.port = port;
            stream = tcpClient.GetStream();
            encoding = new ASCIIEncoding();
        }

        public void sendData(string data)
        {
            byte[] byteSend = encoding.GetBytes(data);
            stream.Write(byteSend, 0, byteSend.Length);
            Console.WriteLine($"Send: {data}");
        }

        public string receiveData()
        {
            byte[] byteReceive = new byte[100];
            string data = "";
            do
            {
                stream.Read(byteReceive, 0, 100);

                data = encoding.GetString(byteReceive);
                char byte0 = (char)0;
                data = data.Replace(byte0.ToString(), "");
            } while (data == "");
            
            Console.WriteLine($"Receive: {data}");
            return data;
        }
    }
}
