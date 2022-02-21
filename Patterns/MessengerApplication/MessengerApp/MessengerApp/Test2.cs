using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp
{
    public class Test2
    {
        public string secret { get; set; }

        public Test2(string secret)
        {
            this.secret = secret;

            Messenger.Subscribe(321, (obj) =>
            {
                Console.WriteLine(this.secret);
            });
        }

        public void GetTest1Secret()
        {
            Messenger.Send(123, new object());
        }
    }
}
