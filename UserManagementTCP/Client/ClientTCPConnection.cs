using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ClientTCPConnection
    {

        IPEndPoint IPServer;
        Socket client;
        int port = 9999;
        string ip = "127.0.0.1";
        int byteSent;
        int byteRecieved;

        public ClientTCPConnection()
        {
        }
        public void CreateSocket()
        {
            IPServer = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            try
            {   
                client.Connect(IPServer);
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới server\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Close()
        {
            try
            {
                client.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                client.Close();
            }
            }

        public void ShutDown()
        {
            client.Shutdown(SocketShutdown.Both);
        }
        public void Send(string msg)
        {
            if (msg != string.Empty)
                byteSent = client.Send(Serialize(msg));
        }

        string message = string.Empty;
        public string Recieve()
        {
            try
            {

                byte[] data = new byte[1024];
                byteRecieved = client.Receive(data);

                message = DeSerialize(data);
                return message;
            }
            catch
            {
                Close();
                return string.Empty;
            }
        }

        public byte[] Serialize(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        public string DeSerialize(byte[] data)
        {
            return Encoding.ASCII.GetString(data);
        }
    }
}

