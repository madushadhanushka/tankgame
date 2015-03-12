using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Net;

namespace game
{
    class RecieveData
    {
        private Int32 port = 7000;
        private TcpListener listn;
        String response;
        public String connect()
        {
            try
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                listn = new TcpListener(ip, port);
                listn.Start();

                Console.WriteLine("The server is running at port 7000...");
                Console.WriteLine("The local End point :" +
                                  listn.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket socket = listn.AcceptSocket();
                Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);
                byte[] buffer = new byte[1024];
                int k = socket.Receive(buffer);

                response = System.Text.Encoding.ASCII.GetString(buffer, 0, k);
                Console.Write(response);

                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");

                socket.Close();
                listn.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                response = null;
            }
            return response;
        }
    }
}
