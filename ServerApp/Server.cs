using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public static class Server
    {
        // This server method sends data to the client
        public static void Sendler(string? multicastAddress, int range, int port)
        {
            
            UdpClient udpClient = new UdpClient();
            udpClient.JoinMulticastGroup(IPAddress.Parse(multicastAddress));
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(multicastAddress), port);

            Random random = new Random();
            while (true)
            {
                int number = random.Next(range);
                byte[] buffer = Encoding.ASCII.GetBytes(number.ToString());
                udpClient.Send(buffer, buffer.Length, remoteEndPoint);
            }
        }
    }
}
