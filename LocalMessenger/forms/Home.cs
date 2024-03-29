using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMessenger
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void HostBtn_Click(object sender, EventArgs e)
        {
            var hostPage = new HostPage();
            hostPage.Show();
            //this.Hide();
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            var joinPage = new JoinPage();
            joinPage.Show();
            //this.Hide();
        }
    }
}
