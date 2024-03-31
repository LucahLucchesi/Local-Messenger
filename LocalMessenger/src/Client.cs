using System;
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
        public Client(string serverIP, int port)
        {
            client = new TcpClient(serverIP, port);
            _ = receiveMessage();
        }
        public void getServerInfo()
        {

        }
        public void sendMsg(string msg)
        {
            byte[] data = Encoding.ASCII.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
        public async Task receiveMessage()
        {
            try
            {
                stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    chatBox.Text += message;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }
        public void Stop()
        {
            stream.Close();
            client.Close();
        }
        public void setChatBoxRef(TextBox chatBox)
        {
            this.chatBox = chatBox;
        }
    }
}
