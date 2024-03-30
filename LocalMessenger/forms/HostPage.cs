using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LocalMessenger.Server;

namespace LocalMessenger
{
    public partial class HostPage : Form
    {
        public HostPage()
        {
            InitializeComponent();
        }


        private void hostBtn_Click(object sender, EventArgs e)
        {
            if(roomNameBox.Text != "" && usrNameBox.Text != "")
            {
                // should be put in a try-catch
                // upon failure to create a server, do NOT attempt to create messenger form
                Server server = new Server((int)portBox.Value, (int)roomSizeBox.Value);
                //server.StartServer();
                var msgPage = new Messenger(roomNameBox.Text, (int) roomSizeBox.Value, usrNameBox.Text, server.getIP(), server);
                msgPage.Show();
            }
        }
    }
}
