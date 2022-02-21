using System;

namespace MessengerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1 test1 = new Test1("qwerty");
            Test2 test2 = new Test2("test");

            test2.GetTest1Secret();
        }
    }
}
