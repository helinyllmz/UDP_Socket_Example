 // 14.04.2023 Author: Helin Yılmaz

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_Socket_Example
{
    class Program
    {
        public static int BufferSize { get; private set; }

        static void Main(string[] args)
        {

            Client();
        }

        private static void Client()
        { 

            // Create client socket
            Socket clientSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            IPAddress IPAddress = IPAddress.Parse("127.0.0.1");
            int clientPortNum = 60000;
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress, clientPortNum);
            clientSocket.Bind(clientEndPoint);


            // Send a message to server
            IPAddress serverIPAddress = IPAddress.Parse("127.0.0.1");
            int serverPortNum = 50000;
            IPEndPoint serverEndPoint = new IPEndPoint(serverIPAddress, serverPortNum);
            string messageToSend = "Hello World";
            byte[] bytesToSend = Encoding.ASCII.GetBytes(messageToSend);
            clientSocket.SendTo(bytesToSend, serverEndPoint);


            // Listen for incoming message
            byte[] receivedBytes = new byte[BufferSize];
            clientSocket.Receive(receivedBytes);

            //Log received message to user
            string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
            Console.WriteLine(receivedMessage);

         }







    }








}
