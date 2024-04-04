using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalMessenger
{
    public class Server
    {
        private TcpListener server;
        private List<TcpClient> clientList = new List<TcpClient>();
        private IPAddress ipAddress = null;
        private int clientsInLobby = 0;
        private int maxLobby;
        private TextBox chatBox = null; //This is redundant now, make a getter or push message to Messenger.
        private Messenger msgWindowRef;

        public Server(int port, int maxLobby)
        {
            this.maxLobby = maxLobby;
            try
            {
                ipAddress = getLocalIP();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (ipAddress != null)
            {
                server = new TcpListener(ipAddress, port);
            }
            
        }

        public async Task StartServer()
        {
            try
            {
                server.Start();
                while(true)
                {
                    TcpClient tempClient = await server.AcceptTcpClientAsync();
                    if (clientsInLobby < maxLobby - 1)
                    {
                        clientList.Add(tempClient);

                        _ = HandleClient(tempClient);
                        clientsInLobby++;
                        msgWindowRef.setCurUsers(clientsInLobby + 1);
                        sendServerInfo(tempClient);
                    }
                    else
                    {
                        tempClient.GetStream().Close();
                        tempClient.Close();
                    }
                }
                
                
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }

        private async Task HandleClient(TcpClient client) 
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while((bytesRead = await client.GetStream().ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    string[] msgs = message.Split(Environment.NewLine.ToCharArray());
                    foreach (string msg in msgs)
                    {
                        parseMessage(msg);
                        _ = sendMsg(msg); //send message async
                    }
                }
                clientsInLobby--;
                msgWindowRef.setCurUsers(clientsInLobby + 1);
                clientList.Remove(client);
                client.GetStream().Close();
                client.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
            
        }
        public void Stop() //this probably needs to send a message to each of the clients saying server closed and disable their input.
        {
            _ = sendMsg("Host has closed the lobby.\r\n");
            foreach(TcpClient client in clientList)
            {
                try
                {
                    client.GetStream().Close();
                    client.Close();
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            server.Stop();
        }

        private IPAddress getLocalIP() //changed to private function, no one needs access to this.
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public string getIP()
        {
            return ipAddress.ToString();
        }

        public async Task sendMsg(string msg)
        {

            byte[] data = Encoding.ASCII.GetBytes(msg);
            foreach (TcpClient client in clientList)
            {
                try
                {
                    await client.GetStream().WriteAsync(data, 0, data.Length);
                }catch(IOException e)
                {
                    Console.WriteLine($"IOException: {e.Message}");
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine($"ObjectDisposedException: {e.Message}");
                }catch(Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                } 
            }
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
            else
            {
                if (msg.Length > 0)
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

        private void sendServerInfo(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            _ = directMsg(stream, "#" + (clientsInLobby + 1) + "\r\n");
            _ = directMsg(stream, "%" + maxLobby + "\r\n");
            _ = directMsg(stream, "&" + msgWindowRef.getLobbyName() + "\r\n");
            foreach(string user in msgWindowRef.getUsers().Items)
            {
                _ = directMsg(stream, "$" + user + "\r\n");
            } 
        }

        private async Task directMsg(NetworkStream stream, string msg)
        {
            byte[] data = Encoding.ASCII.GetBytes(msg);
            await stream.WriteAsync(data, 0, data.Length);
        }
    }
}
