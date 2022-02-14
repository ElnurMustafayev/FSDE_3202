using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApplication
{
    public class SingletonContainer<T>
    {
        public string text = "qwerty";
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance is null)
                    instance = Activator.CreateInstance<T>();
                return instance;
            }
        }

        private SingletonContainer()
        {

        }
    }
}
