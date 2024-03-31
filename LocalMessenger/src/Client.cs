using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LocalMessenger
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        public Client(string serverIP, int port)
        {
            client = new TcpClient(serverIP, port);
            stream = client.GetStream();
        }
        public void getServerInfo()
        {

        }
        public void sendMsg(string msg)
        {
            byte[] data = Encoding.ASCII.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }

        public void Stop()
        {
            stream.Close();
            client.Close();
        }
    }
}
