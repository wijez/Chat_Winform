using System.Net.Sockets;

namespace Server
{
    internal class ClientInfo : TcpClient
    {
        public TcpClient Client { get; set; }
        public string ClientName { get; set; }
    }
}