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
    public partial class OpenMultiForm : Form
    {
        public OpenMultiForm()
        {
            InitializeComponent();
        }

        private void OpenMultiForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            ClientMainForm clientMainForm;
            int i = 1;
            while (i-- != 0)
            {
                clientMainForm = new ClientMainForm();
                clientMainForm.Show();
            }
        }
    }
}
