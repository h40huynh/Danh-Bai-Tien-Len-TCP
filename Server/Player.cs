using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Player
    {
        private int id;
        private int idRoom;
        private Socket socket;
        private int money;

        private byte[] byteReceive;
        private int bufferLength = 100;

        private static int recentId = 0;

        public string getName() => $"User{id}";
        public int getMoney() => money;
        public int getID() => id;
        public int getIDRoom() => idRoom;
        public void setIDRoom(int id) { idRoom = id; }

        public Player(Socket socket)
        {
            this.socket = socket;
            id = recentId++;
            byteReceive = new byte[bufferLength];
        }

        public void sendData(string data)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byteSend = encoding.GetBytes(data);
            socket.Send(byteSend);
        }

        public string receiveData()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            socket.Receive(byteReceive);

            string data = encoding.GetString(byteReceive);
            return data;
        }

        public void closeConnection()
        {
            socket.Close();
        }
       
    }
}
