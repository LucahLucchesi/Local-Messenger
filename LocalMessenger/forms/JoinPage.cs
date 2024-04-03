using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LocalMessenger.Client;

namespace LocalMessenger
{
    public partial class JoinPage : Form
    {
        public JoinPage()
        {
            InitializeComponent();
        }

        
        private void joinBtn_Click(object sender, EventArgs e)
        {
            if (ipTextBox.Text != "" && usrNameTextBox.Text != "")
            {
                try
                {
                    Client client = new Client(ipTextBox.Text, (int)portBox.Value);
                    var msgPage = new Messenger("placeholder", 0, usrNameTextBox.Text, ipTextBox.Text, client);
                    msgPage.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
