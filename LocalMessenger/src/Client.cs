using System;
using System.Net.Sockets;
using System.Text;

namespace LocalMessenger
{
    public class Client
    {
        private TcpClient client;
        public Client(string serverIP, int port)
        {
            client = new TcpClient(serverIP, port);
        }

        public void SendMessage(string message)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] responseBuffer = new byte[1024];
                int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                Console.WriteLine("Server response: " + response);

                stream.Close();
                client.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
