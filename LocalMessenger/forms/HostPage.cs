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
                var msgPage = new Messenger(roomNameBox.Text, (int) RoomSizeBox.Value, usrNameBox.Text);
                msgPage.Show();
            }
        }
    }
}
