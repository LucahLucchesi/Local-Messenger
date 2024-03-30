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
        private String ipAddr;
        private Server serverRef;
        private Client clientRef; //added constructors for both server and client. one of these will be null.

        public Messenger(String roomName, int roomSize, String userName, String ipAddr, Server serverRef) //Server based constructor
        {
            this.roomName = roomName;
            this.roomSize = roomSize;
            this.userName = userName;
            this.ipAddr = ipAddr;
            this.serverRef = serverRef;
            this.clientRef = null;
            InitializeComponent();
            userGroupBox.Text = "Users (1/" + roomSize.ToString() + ")";
            this.Text = this.roomName + " (1/" + roomSize.ToString() + "): " + ipAddr;
            usersList.Items.Add(this.userName);
            serverRef.setBoxRefs(chatWindow, msgInputBox);
        }

        public Messenger(String roomName, int roomSize, String userName, String ipAddr, Client clientRef) //Client based constructor
        {
            this.roomName = roomName;
            this.roomSize = roomSize;
            this.userName = userName;
            this.ipAddr = ipAddr;
            this.serverRef = null;
            this.clientRef = clientRef;
            InitializeComponent();
            userGroupBox.Text = "Users (1/" + roomSize.ToString() + ")";
            this.Text = this.roomName + " (1/" + roomSize.ToString() + "): " + ipAddr;
            usersList.Items.Add(this.userName);
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            serverRef.sendMsg(userName);
        }
    }
}
