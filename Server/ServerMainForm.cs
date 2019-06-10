using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerMainForm : Form
    {
        private TcpModel tcpModel;
        private List<Player> players = new List<Player>();
        private List<Room> rooms = new List<Room>();



        public ServerMainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            startServer();
            //this.Size = new Size(1, 1);
        }

        private void startServer(bool isDefault = true)
        {
            if(isDefault)
            {
                tcpModel = new TcpModel("127.0.0.1", 8080);
            }
            else
            {
                tcpModel = new TcpModel(txtIP.Text, int.Parse(txtPort.Text));
            }

            tcpModel.start();
            rtxtLog.Text += isDefault ? "Server is running on 127.0.0.1:8080\n" : $"Server is running on {txtIP.Text}:{txtPort.Text}\n";
            lblStatus.Text = "Running";

            Thread thread = new Thread(listenThread);
            thread.Start();
            
            // Disable all connect button
            btnStart.Enabled = false;
            btnStartDefault.Enabled = false;
        }

        private void listenThread()
        {
            while (true)
            {
                Socket socket = tcpModel.listen();
                Player player = new Player(socket);

                players.Add(player);
                rtxtLog.Text += $"{player.getName()} join game.\n";
                player.sendData("user " + player.getID().ToString());

                Thread thread = new Thread(reciveDataThread);
                thread.Start(player);
            }
        }

        private void reciveDataThread(object obj)
        {
            Player player = obj as Player;
            string name = player.getName();
            try
            {
                while (true)
                {
                    string data = player.receiveData();
                    rtxtLog.Text += $"From {name}: {data}\n";
                    rtxtLog.Text += "\n";

                    string[] fixData = data.Split(' ');
                    switch(fixData[0])
                    {
                        case "create"://yêu cầu tạo phòng
                            Room newRoom = new Room(int.Parse(fixData[2]), rooms.Count);
                            newRoom.addPlayer(player);
                            rooms.Add(newRoom);
                            break;

                        case "join":// yêu cầu chơi phòng ngẫu nhiên
                            join(player);
                            break;

                        case "winner"://client thắng gửi, kết thúc ván
                            rooms[player.getIDRoom()].endGame(data, player);
                            break;

                        case "pop":
                            rooms[player.getIDRoom()].mergeCard(data);
                            rooms[player.getIDRoom()].sendCardToPlayer(data, player);
                            break;

                        case "miss"://client bỏ lượt
                            rooms[player.getIDRoom()].sendCardToPlayer(data, player);
                            break;

                        case "close":
                            rooms[player.getIDRoom()].deletePlayer(player);
                            player.closeConnection();
                            break;
                        case "lose":
                            rooms[player.getIDRoom()].mergeCard(data);
                            break;
                        case "chat":
                            data = data.Substring(5);
                            rooms[player.getIDRoom()].chat(data, player);
                            break;
                        case "quit":
                            rooms[player.getIDRoom()].deletePlayer(player);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                player.closeConnection();
                rtxtLog.Text += $"Close connection from {name}.\n";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                startServer(false);                
            }
            catch (Exception)
            {
                MessageBox.Show("Check IP or port.\nError from function startServer.");
            }
        }

        private void btnStartDefault_Click(object sender, EventArgs e)
        {
            startServer();
        }

        private void join(Player newPlayer)
        {

            for(int i = 0; i< rooms.Count; i++)
            {
                if (rooms[i].isReady() == false)
                {
                    rooms[i].addPlayer(newPlayer);
                    return;
                }
            }

            Room newRoom = new Room(3000, rooms.Count);
            newRoom.addPlayer(newPlayer);
            rooms.Add(newRoom);
                
        }
    }
}
