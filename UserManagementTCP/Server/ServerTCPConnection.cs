using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Microsoft.IdentityModel.Tokens;

namespace Server
{
    class ServerTCPConnection
    {
        byte[] bytes = new byte[1024];
        List<Socket> clientList = new List<Socket>();
        IPEndPoint IPClient;
        Socket server;
        ManipulateDataBase DTBConnection = new ManipulateDataBase();
        string fail = "Fail";
        string success = "Succ";

        public ServerTCPConnection()
        {

        }

        public void Connect()
        {
            IPClient = new IPEndPoint(IPAddress.Any,5000);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IPClient);

            Thread Listening = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        Thread Recieving = new Thread(Recieve);
                        Recieving.IsBackground = true;
                        Recieving.Start(client);
                    }
                }catch
                {
                    IPClient = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            Listening.IsBackground = true;
            Listening.Start();
        }

        public void Close()
        {
            server.Close();
        }

        public void Send(Socket client, string msg)
        {   
            if (msg != string.Empty)
                client.Send(Serialize(msg));
        }

        public void Recieve(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while(true)
                {
                    byte[] data = new byte[1024];
                    client.Receive(data);

                    string message = DeSerialize(data);
                    if (message.Substring(0,6) == "Select")
                    {
                        try
                        {
                            if (DTBConnection.ToQuery(message).Count > 0)
                            {
                                Send(client, fail);
                            }
                            else
                            {
                                Send(client, success);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Send(client, "Error");
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                    }
                    else if (message.Substring(0,6) == "Insert")
                    {
                        try
                        {
                            DTBConnection.Command(message);
                            Send(client, success);
                        }
                        catch
                        {
                            Send(client,fail);
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                    }
                    else if (message.Substring(0,6) == "SELECT")
                    {
                        try
                        {
                            Account acc = DTBConnection.GetAccount(message);
                            string str = acc.UserId.ToString() + "*";
                            str += acc.Username + "*";
                            str += acc.Email + "*";
                            str += acc.Fullname + "*";
                            str += acc.Birthday;
                            Send(client, str);
                        }
                        catch (Exception ex)
                        {
                            Send(client, fail);
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                        }
                    }
                }
            }
            catch
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Close();
            }
        }

        public byte[] Serialize(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        public string DeSerialize(byte[] data)
        {
            return Encoding.ASCII.GetString(data,0,data.Length).Trim('\0');
        }
    }
}
