using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp
{
    public class Test1
    {
        public string secret { get; set; }

        public Test1(string secret)
        {
            this.secret = secret;

            Messenger.Subscribe(123, (obj) =>
            {
                Console.WriteLine(this.secret);
            });
        }

        public void GetTest2Secret()
        {
            Messenger.Send(new Test1Message());
        }
    }
}
