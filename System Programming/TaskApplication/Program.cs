using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskApplication
{
    class Program
    {
        static int GetNumberSync()
        {
            Thread.Sleep(1500);
            return new Random().Next(15000, 100000);
        }

        static void GetNumberWithThread1()
        {
            new Thread(() =>
            {
                Console.WriteLine(GetNumberSync());
            }).Start();
        }

        static int GetNumberWithThread2()
        {
            int number = 0;

            new Thread(() =>
            {
                number = GetNumberSync();
            }).Start();

            return number;
        }

        static int GetNumberWithThreadSync()
        {
            int number = 0;

            var thread = new Thread(() =>
            {
                number = GetNumberSync();
            });

            thread.Join();

            return number;
        }

        static Task<int> GetNumberAsync()
        {
            return Task.Run<int>(() =>
            {
                Thread.Sleep(2000);
                return new Random().Next(15000, 100000);
            });
        }

        static async void Start()
        {
            var number = await GetNumberAsync();

            Console.WriteLine($"Result is {number}");
        }


        static void Main(string[] args)
        {
            if(false)
            {
                var number = GetNumberSync();
                Console.WriteLine(number);

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }

            if(false)
            {
                GetNumberWithThread1();

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }

            if(false)
            {
                var number = GetNumberWithThread2();

                Console.WriteLine(number);
            }

            if(false)
            {
                var number = GetNumberWithThreadSync();

                Console.WriteLine(number);
            }

            if(false)
            {
                Action action = new Action(() =>
                {
                    Console.WriteLine("Thread Start...");
                    Thread.Sleep(1500);
                    Console.WriteLine("Thread End...");
                });

                var task = Task.Run(action);

                task.Wait();

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }

            if(false)
            {
                var tasks = new Task[]
                {
                    new Task(() =>
                    {
                        Thread.Sleep(2500);
                        Console.WriteLine("Task 1 end...");
                    }),
                    new Task(() =>
                    {
                        Thread.Sleep(1500);
                        Console.WriteLine("Task 2 end...");
                    }),
                };

                foreach (var task in tasks)
                {
                    task.RunSynchronously();
                }

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }

            if(false)
            {
                var tasks = new Task[]
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(2500);
                        Console.WriteLine("Task 1 end...");
                    }),
                    Task.Run(() =>
                    {
                        Thread.Sleep(1500);
                        Console.WriteLine("Task 2 end...");
                    }),
                };

                Task.WaitAll(tasks);

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }
        
            if(false)
            {
                Task<string> task = Task.Run<string>(() =>
                {
                    Thread.Sleep(3000);
                    var guidStr = Guid.NewGuid().ToString();
                    return guidStr;
                });

                var result = task.Result;
                Console.WriteLine(result);

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            }

            if(false)
            {
                Start();

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }

                Console.ReadKey();
            }

            if(false)
            {
                var task = Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Thread end!");
                }).ContinueWith(t =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Task id is: {t.Id}");
                }).ContinueWith(t =>
                {
                    Console.WriteLine("All tasks end!");
                });

                task.Wait();
            }

            if(false)
            {
                var token = new CancellationTokenSource();

                Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine(i);
                    }
                }, token.Token);

                Thread.Sleep(2000);
                token.Cancel();

                Console.ReadKey();
            }

            if(false)
            {
                var task1 = Task.Factory.StartNew(() => { Thread.Sleep(3000); Console.WriteLine("First"); });
                var task2 = Task.Factory.StartNew(() => { Thread.Sleep(2000); Console.WriteLine("Second"); });
                var task3 = Task.Factory.StartNew(() => { Thread.Sleep(1000); Console.WriteLine("Third"); });

                Task.Factory.ContinueWhenAll(
                    tasks: new Task[] { task1, task2, task3 },
                    continuationAction: tasks =>
                    {
                        tasks.ToList().ForEach(t =>
                        {
                            Console.WriteLine($"Thread {t.Id} end!");
                        });
                    }
                    );

                Console.ReadKey();
            }
        }
    }
}
