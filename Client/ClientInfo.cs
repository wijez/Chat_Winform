using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ClientInfo
    {

        public TcpClient Client { get; set; }
        public string ClientName { get; set; }
    }
}
