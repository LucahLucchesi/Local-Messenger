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
        private int curUsers = 1;
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
            this.serverRef.setChatBoxRef(chatWindow);
            this.serverRef.setWindowRef(this);
            _ = this.serverRef.StartServer();
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
            clientRef.setChatBoxRef(chatWindow);
            clientRef.setWindowRef(this);
            clientRef.sendClientInfo();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //Create a message with username attached
            String builtMsg = "[" + userName + "]" + ": " + msgInputBox.Text + "\r\n";
            
            if(serverRef != null) //if we are the server we want to see our message and send it to all clients
            {
                _ = serverRef.sendMsg(builtMsg);
                chatWindow.Text += builtMsg;
            }
            else //The client will send the server its message, Message will only appear when server responds with own message.
            {
                clientRef.sendMsg(builtMsg);
            }
            msgInputBox.Clear();

        }

        public void setLobbyName(string newLobbyName)
        {
            this.roomName = newLobbyName;
            updateHeaders();
        }

        public void setRoomSize(int rmSize)
        {
            this.roomSize = rmSize;
            updateHeaders();
        }

        public void setCurUsers(int curUsers)
        {
            this.curUsers = curUsers;
            updateHeaders();
        }

        private void updateHeaders()
        {
            this.Text = this.roomName + " (" + curUsers.ToString() +"/" + roomSize.ToString() + "): " + ipAddr;
            userGroupBox.Text = "Users (" + curUsers.ToString() + "/" + roomSize.ToString() + ")";
        }

        // handles the messenger form closing
        // add confirmation window. setting e.cancel to true will prevent the messenger from closing
        private void Messenger_FormClosing(object sender, FormClosingEventArgs e)
        {

            // stop server if the messenger is the host
            if (serverRef != null)
            {
                var closeLobby = MessageBox.Show("Are you sure you want to close the server?", "Exit", MessageBoxButtons.YesNo);
                if (closeLobby == DialogResult.No) e.Cancel = true;
                else serverRef.Stop();
                return;
            }
            var leaveLobby = MessageBox.Show("Leave lobby?", "Exit", MessageBoxButtons.YesNo);
            if (leaveLobby == DialogResult.No) e.Cancel = true;
            else clientRef.Stop("[" + userName + "] has left.\r\n");
        }

        public void addUser(string newUser)
        {
            usersList.Items.Add(newUser);
        }

        public void removeUser(string remUser)
        {
            usersList.Items.Remove(remUser);
        }

        public string getLobbyName()
        {
            return roomName;
        }

        public ListBox getUsers()
        {
            return usersList;
        }

        public string getUserName()
        {
            return userName;
        }
    }
}
