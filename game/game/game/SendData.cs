
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;

namespace game
{
    class SendData
    {
        private Int32 port = 6000;
        private NetworkStream stream;
        private TcpClient client;
        private TcpListener tcpListn;

        public void connect()
        {
            try
            {
                client = new TcpClient("127.0.0.1",port);
                stream = client.GetStream();
                Console.WriteLine("Connected");

            }
            catch (SocketException e)
            {

                Console.WriteLine("Error: " + e);
            }
        }
        public void sendMessage(String message)
        {
            try
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("MSG sent:" + message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
        public void disconnect()
        {
            try
            {
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
   
    }
}
