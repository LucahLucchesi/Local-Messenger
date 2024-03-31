using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LocalMessenger
{
    public class Server
    {
        private TcpListener server;
        private IPAddress ipAddress = null;
        private int numLobby = 1;
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

        private async void acceptNewClient()
        {
            //TODO: if there is room, await new client. when client is accepted, need to pass information to the window and update the people in the room accordingly
            // probably going to need a global client list and just append the client.
        }

        public void StartServer()
        {
            try
            {
                server.Start();
                //move this to async method that checks if new clients can be accepted
                
                    // Accepts a new client connection
                TcpClient client = server.AcceptTcpClient();
                HandleClient(client);
            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }

        private void HandleClient(TcpClient client) //probably needs to be some sort of asyncronous function that can handle multiple client inputs.
        {
            NetworkStream stream = client.GetStream();
            

            byte[] buffer = new byte[1024];
            int bytesRead;

            while((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                chatBox.Text += message;

                sendMsg(message);
            }

            client.Close();
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

        public void sendMsg(string msg)
        {

            // send msg to all clients

        }
        public void setChatBoxRef(TextBox chatBox)
        {
            this.chatBox = chatBox;
        }
    }
}
