using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace ThreadApplication
{
    public class TimerOption
    {
        public string Data { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            if(false)
            {
                // 1
                ParameterizedThreadStart threadStart1 = new ParameterizedThreadStart(ShowObject);
                // 2
                ParameterizedThreadStart threadStart2 = ShowObject;
                // 3
                ParameterizedThreadStart threadStart3 = delegate (object? obj)
                {
                    Console.WriteLine(obj);
                };
                // 4
                ParameterizedThreadStart threadStart4 = (obj) => Console.WriteLine(obj);
            }

            if(false)
            {
                var thread = new Thread(ShowObject)
                {
                    Name = "MyThread",
                    IsBackground = true,
                };

                thread.Start("Hello World!");

                Console.WriteLine("End");
            }

            if(false)
            {
                int x = 0;
                var thread = new Thread(() => {
                    x = 100; 
                });

                thread.Start();
                

                Console.WriteLine(x + 10);
                thread.Join();
                Console.WriteLine(x + 10);
            }

            if(false)
            {
                var thread = new Thread(() => Console.WriteLine("Hello World!"));
                thread.Start();

                thread.Abort();     // close thread force

                thread.Suspend();   // pause thread

                thread.Resume();    // continue thread
            }

            if(false)
            {
                TimerOption option = new TimerOption()
                {
                    Data = "Option Data",
                };

                Timer time = new Timer((obj) =>
                {
                    if(obj is TimerOption option)
                    {
                        Console.WriteLine(option.Data);
                    }
                }, option, 1000, 1000);

                Console.ReadKey();
            }

            if(false)
            {
                int x = 0;
                string locker = string.Empty;

                Mutex mutex = new Mutex();
                Semaphore semaphore = new Semaphore(50, 100);

                new Thread(() =>
                {
                    Console.WriteLine("Thread start");
                    for (int i = 0; i < 1000000; i++)
                    {
                        //semaphore.WaitOne();
                        //x++;
                        //semaphore.Release();

                        //mutex.WaitOne();
                        //x++;
                        //mutex.ReleaseMutex();

                        //lock(locker)
                        //{
                        //    x++;
                        //}

                        //Monitor.Enter(locker);
                        //x++;
                        //Monitor.Exit(locker);

                        //Interlocked.Increment(ref x);
                    }
                    Console.WriteLine("Thread end");
                }).Start();

                new Thread(() =>
                {
                    Console.WriteLine("Thread start");
                    for (int i = 0; i < 1000000; i++)
                    {
                        semaphore.WaitOne();
                        x++;
                        semaphore.Release();
                    }
                    Console.WriteLine("Thread end");
                }).Start();

                Console.ReadKey();

                Console.WriteLine(x);
            }

            if(false)
            {
                Mutex mutex = new Mutex(true, "My Mutex Application", out bool createdNew);
                if(createdNew)
                {
                    Thread.Sleep(10000);
                }
            }
        }

        static void ShowObject(object? obj)
        {
            Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' start...");
            Thread.Sleep(2000);
            Console.WriteLine(obj);
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}' end...");
        }
    }
}
