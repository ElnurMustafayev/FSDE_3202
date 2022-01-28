using System;
using System.Linq;
using System.Collections.Generic;
using System.MyLinq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PararellProgramming
{
    class Program
    {
        static CancellationTokenSource token = new CancellationTokenSource();
        static void Main(string[] args)
        {
            if (false)
            {
                var token = new CancellationTokenSource();

                bool canceled = false;
                canceled = true;

                Task.Run(() =>
                {
                    DoSomethingBigWithToken(token.Token);
                });


                Thread.Sleep(3000);
                token.Cancel();

                Console.WriteLine("Main end!");
                Console.ReadKey();
            }

            if (false)
            {
                var list = new List<Person>()
                {
                    new Person("John", 12),
                    new Person("Ann", 21),
                    new Person("Bob", 31),
                    new Person("Jake", 42),
                };

                var adultPeople = list.Where(p => p.Age > 18)
                    .Take(10);

                var john = new Person("John", 12);

                foreach (var person in adultPeople)
                {
                    Console.WriteLine(person);
                }

                // Decorator
                john.SetAge(10).SetName("Alice").SetName("Qwerty");
                Console.WriteLine(john);
            }

            if (false)
            {
                Action[] actions = new Action[]
                {
                    () =>
                    {
                        Thread.Sleep(3000);
                        Console.WriteLine("Work 1 end");
                    },
                    () =>
                    {
                        Thread.Sleep(2000);
                        Console.WriteLine("Work 2 end");
                    },
                    () =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Work 3 end");
                    },
                };

                Parallel.Invoke(new ParallelOptions()
                {
                    CancellationToken = token.Token
                }, actions);

                Thread.Sleep(1500);
                token.Cancel();

                Console.ReadKey();
            }

            if (true)
            {
                Parallel.
            }
        }

        public static void DoSomethingBigWithToken(CancellationToken token)
        {
            try
            {
                for (int i = 0; i < 1000000; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("Loop canceled!");
                        break;
                    }

                    Thread.Sleep(1);
                }
            }
            catch(OperationCanceledException ex)
            {
                Console.WriteLine($"Operation calceled by token\nError message: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("System exception: " + ex.Message);
            }
        }

        public static void DoSomethingBig(ref bool canceled)
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (canceled)
                {
                    Console.WriteLine("Loop canceled!");
                    break;
                }

                Thread.Sleep(1);
            }
        }
    }
}