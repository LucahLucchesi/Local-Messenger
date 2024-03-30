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

        public Server(int port)
        {
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

        public void StartServer()
        {
            try
            {
                server.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while (true)
                {
                    // Accepts a new client connection
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected");
                    HandleClient(client);
                }

            }catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            while((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Recieved: " + message);

                byte[] response = Encoding.ASCII.GetBytes("Message received");
                stream.Write(response, 0, response.Length);
            }

            client.Close();
        }
        public void Stop()
        {
            server.Stop();
        }

        public IPAddress getLocalIP()
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
    }
}
