using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp
{
    public static class Messenger
    {
        private static Dictionary<Type, List<Action<object>>> Subscribers;

        static Messenger()
        {
            Subscribers = new Dictionary<Type, List<Action<object>>>();
        }

        public static void Send<T>(T message) where T : IMessage
        {
            var key = typeof(T);
            if (Subscribers.ContainsKey(key) == false)
                return;

            foreach (var action in Subscribers[key])
                action?.Invoke(message);
        }

        public static void Subscribe<T>(Action<object> action) where T : IMessage
        {
            var key = typeof(T);
            if (Subscribers.ContainsKey(key) == false)
                Subscribers.Add(key, new List<Action<object>>());

            Subscribers[key].Add(action);
        }
    }
}
