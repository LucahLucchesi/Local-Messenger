using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LocalMessenger
{
    public class Server
    {
        private TcpListener server;

        public Server(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            server = new TcpListener(ipAddress, port);
        }

        public void Start()
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
    }
}
