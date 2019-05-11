using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void connect()
        {
            tcpModel = new TcpModel(txtIP.Text, int.Parse(txtPort.Text));
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
    }
}
