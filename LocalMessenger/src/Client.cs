﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMessenger
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        private TextBox chatBox;
        private Messenger msgWindowRef;
        
        public Client(string serverIP, int port)
        {
            // tries to establish a connection to the server
            // exception is thrown to JoinPage.cs
            try
            {
                client = new TcpClient(serverIP, port);
                stream = client.GetStream();
                _ = receiveMessage();
                
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public void sendClientInfo()
        {
            while(msgWindowRef == null) { }
            sendMsg("$" + msgWindowRef.getUserName() + "\r\n");
        }

        public void sendMsg(string msg)
        {
            // sends a message to the server. Will not send if server is closed
            byte[] data = Encoding.ASCII.GetBytes(msg);
            try
            {
                stream.Write(data, 0, data.Length);
            }catch(Exception) {
                MessageBox.Show("Host has shut down the server.");
            }
            
        }
        public async Task receiveMessage()
        {
            try
            {
                
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    string[] msgs = message.Split(Environment.NewLine.ToCharArray());
                    foreach(string msg in msgs)
                    {
                        parseMessage(msg);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }

        
        public void Stop(string msg)
        {
            sendMsg(msg + "\r\n!" + msgWindowRef.getUserName() + "\r\n");
            
            stream.Close();
            client.Close();
        }
        public void setChatBoxRef(TextBox chatBox)
        {
            this.chatBox = chatBox;
        }

        public void setWindowRef(Messenger msgWindow)
        {
            this.msgWindowRef = msgWindow;
        }

        private void parseMessage(string msg)
        {
            if (msg.StartsWith("$")) //Contains a new username to be added
            {
                msg = msg.Substring(1);
                msgWindowRef.addUser(msg);
            }
            else if (msg.StartsWith("!")) //This user has left
            {
                msg = msg.Substring(1);
                msgWindowRef.removeUser(msg);
            }
            else if (msg.StartsWith("#"))
            {
                msg = msg.Substring(1);
                int newCurUsers = int.Parse(msg);
                msgWindowRef.setCurUsers(newCurUsers);
            }
            else if (msg.StartsWith("%"))
            {
                msg = msg.Substring(1);
                int lobbySize = int.Parse(msg);
                msgWindowRef.setRoomSize(lobbySize);
            }
            else if (msg.StartsWith("&"))
            {
                msg = msg.Substring(1);
                msgWindowRef.setLobbyName(msg);
            }
            else
            {
                if(msg.Length > 0)
                {
                    chatBox.Text += msg + "\r\n";
                }
                
            }

            /*Commands that need implementation:
                * # (int)c - notifys that an update to the number of people in lobby changed, set to new number
                * $ (string) - Username, add it to the users list
                * ! (string) - Username left, delete user from users list, also should update clientlist to free up slot.
                * % (int)c - Max lobby size, send to new users to initialize lobby information
                * & (String)c - Lobby name, send to new users to initialize lobby information
            */
        }

    }
}
