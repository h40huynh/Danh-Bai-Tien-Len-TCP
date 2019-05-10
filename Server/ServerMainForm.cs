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

        public ServerMainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
                }
            }
            catch (Exception)
            {
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
    }
}
