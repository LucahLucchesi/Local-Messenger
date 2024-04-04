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
                    chatBox.Text += message;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); //message box this?
            }
        }
        public void Stop(string msg)
        {
            sendMsg(msg);
            stream.Close();
            client.Close();
        }
        public void setChatBoxRef(TextBox chatBox)
        {
            this.chatBox = chatBox;
        }
    }
}
