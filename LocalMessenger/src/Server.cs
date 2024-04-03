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
                    TcpClient tempClient = await server.AcceptTcpClientAsync();
                    if (clientsInLobby < maxLobby - 1)
                    {
                        clientList.Add(tempClient);

                        _ = HandleClient(tempClient);
                        clientsInLobby++;
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

                    if (chatBox.InvokeRequired == true)
                        chatBox.Invoke((MethodInvoker)delegate { chatBox.Text += message; });
                    else
                        chatBox.Text += message;

                    _ = sendMsg(message); //send message async
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
            
        }
        public void Stop() //this probably needs to send a message to each of the clients saying server closed and disable their input.
        {
            foreach(TcpClient client in clientList)
            {
                client.GetStream().Close();
                client.Close();
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
    }
}
