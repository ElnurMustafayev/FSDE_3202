using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApplication
{
    public sealed class Singleton
    {
        public string text = "for test";
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance is null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {

        }
    }
}
