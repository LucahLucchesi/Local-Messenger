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
    public partial class Messenger : Form
    {
        private String roomName;
        private int roomSize;
        private String userName;

        public Messenger(String roomName, int roomSize, String userName)
        {
            this.roomName = roomName;
            this.roomSize = roomSize;
            this.userName = userName;
            InitializeComponent();
            userGroupBox.Text = "Users (1/" + roomSize.ToString() + ")";
            this.Text = this.roomName + "(1/" + roomSize.ToString() + ")";
            usersList.Items.Add(this.userName);
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
