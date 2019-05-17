using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientMainForm : Form
    {
        private TcpModel tcpModel;

        public ClientMainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            BtnLocal_Click(null, null);
            
        }

        private void connect()
        {
            tcpModel = new TcpModel(txtIP.Text, int.Parse(txtPort.Text));
            btnConnect.Enabled = false;
            btnCreate.Enabled = btnJoin.Enabled = true;

            Thread thread = new Thread(receiveFromServerThread);
            thread.Start();
        }

        private void receiveFromServerThread()
        {
            while (true)
            {
                string data = tcpModel.receiveData();
                string[] value = data.Split(' ');
                switch(value[0])
                {
                    case "room":
                        using (GameForm gameForm = new GameForm(int.Parse(value[1]), tcpModel))
                        {
                            this.Hide();
                            gameForm.ShowDialog();
                            this.Show();
                        }
                        break;
                    case "user":
                        tcpModel.setID(int.Parse(value[1]));
                        tcpModel.sendData("join ");
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
            }
            catch (Exception)
            {
                MessageBox.Show("Check IP or Port.\nError from fuction connect");
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbbMoneyToPlay.Text);
            tcpModel.sendData($"create room {cbbMoneyToPlay.Text}");
        }

        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            int[] moneyToPlay = { 100, 200, 500, 1000, 5000 };
            foreach(int money in moneyToPlay)
            {
                cbbMoneyToPlay.Items.Add(money);
            }
        }

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            tcpModel.sendData("join ");
        }

        private void BtnLocal_Click(object sender, EventArgs e)
        {
            tcpModel = new TcpModel("127.0.0.1", 8080);
            btnConnect.Enabled = false;
            btnLocal.Enabled = false;
            btnCreate.Enabled = btnJoin.Enabled = true;

            Thread thread = new Thread(receiveFromServerThread);
            thread.Start();
        }
    }
}
