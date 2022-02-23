using Client.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Messages
{
    public class AfterRegistrationMessage : IMessage
    {
        public TcpClient Client { get; set; }
        public string ClientName { get; set; }
        public long ChatId { get; set; }
    }
}
