using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools
{
    public interface IMessenger
    {
        public void Send<T>(T message) where T : IMessage;
        public void Subscribe<T>(Action<object> action) where T : IMessage;
    }
}
