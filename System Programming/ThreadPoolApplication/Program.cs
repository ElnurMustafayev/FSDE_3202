using System;
using System.Threading;

namespace ThreadPoolApplication
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if(false)
            {
                var myThread = new Thread(() =>
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Thread end!!!");
                });

                while (true)
                {
                    Thread.Sleep(1000);
                    myThread.Start();
                }
            }

            if(false)
            {
                WaitCallback callback = delegate (object? obj)
                {
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine($"Current thread ID: {threadId}");
                };

                while (true)
                {
                    //Thread.Sleep(1);
                    ThreadPool.QueueUserWorkItem(delegate (object? obj)
                    {
                        var threadId = Thread.CurrentThread.ManagedThreadId;
                        Console.WriteLine($"Current thread ID: {threadId}");
                    }, null);
                }
            }

            if(false)
            {
                ThreadPool.QueueUserWorkItem(
                    callBack: delegate (Person p) {
                            Console.WriteLine(p);
                        }, 
                    state: new Person("Tamerlan", 25), 
                    preferLocal: true);

                Thread.Sleep(1000);
            }
        }
    }
}
