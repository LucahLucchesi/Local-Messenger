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
        private List<NetworkStream> connectionList = new List<NetworkStream>();
        private IPAddress ipAddress = null;
        private int clientsInLobby = 0;
        private int maxLobby;
        private TextBox chatBox = null;

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
                    if(clientsInLobby < maxLobby - 1)
                    {
                        TcpClient tempClient = await server.AcceptTcpClientAsync();
                        clientList.Add(tempClient);
                        _ = HandleClient(tempClient);
                        clientsInLobby++;
                    }
                }
                
                
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }

        private async Task HandleClient(TcpClient client) //probably needs to be some sort of asyncronous function that can handle multiple client inputs.
        {
            try
            {
                NetworkStream stream = client.GetStream();
                connectionList.Add(stream);
            
                byte[] buffer = new byte[1024];
                int bytesRead;

                while((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    chatBox.Text += message; // confirmed that up to this point works

                    sendMsg(message); //Host freezes after implementing this
                }

            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
            
        }
        public void Stop() //this probably needs to send a message to each of the clients saying server closed and disable their input.
        {
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

        public void sendMsg(string msg) //most likely an error in this function
        {

            for (int i = 0; i < connectionList.Count; ++i)
            {
                byte[] data = Encoding.ASCII.GetBytes(msg);
                connectionList[i].Write(data, 0, data.Length);
            }

        }
        public void setChatBoxRef(TextBox chatBox)
        {
            this.chatBox = chatBox;
        }
    }
}
