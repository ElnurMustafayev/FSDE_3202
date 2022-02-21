using Client.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class Messenger : IMessenger
    {
        public Dictionary<Type, List<Action<object>>> Subscribers { get; private set; }
        public Messenger() => this.Subscribers = new Dictionary<Type, List<Action<object>>>();

        public void Subscribe<T>(Action<object> action) where T : IMessage
        {
            Type key = typeof(T);
            if (!this.Subscribers.ContainsKey(key))
                this.Subscribers[key] = new List<Action<object>>();
            this.Subscribers[key].Add(action);
        }

        public void Send<T>(T message) where T : IMessage
        {
            Type key = typeof(T);
            if (this.Subscribers.ContainsKey(key))
                this.Subscribers[key].ForEach(ac => ac?.Invoke(message));
        }
    }
}
