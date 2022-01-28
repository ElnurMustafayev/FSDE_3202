using System;
using System.Linq;
using System.Collections.Generic;
using System.MyLinq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
                    new Person("John", 12, 1000),
                    new Person("Ann", 21, 2000),
                    new Person("Bob", 31, 2500),
                    new Person("Jake", 42, 400),
                };

                var adultPeople = list.Where(p => p.Age > 18)
                    .Select(p => new { Age = p.Age, Name = p.Name });


                var result = from p in list.AsParallel()
                             where p.Age >= 18
                             select p;

                var john = new Person("John", 12, 1000);

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

            if (false)
            {
                var list = new List<Person>()
                {
                    new Person("John", 12, 1000),
                    new Person("Ann", 21, 2000),
                    new Person("Bob", 31, 2500),
                    new Person("Jake", 42, 400),
                };

                Stopwatch watch = new Stopwatch();

                watch.Start();
                // 6000 ms
                //for (int i = 0; i < list.Count; i++)
                //{
                //    var currentPerson = list[i];
                //    Thread.Sleep(currentPerson.DoWorkTimeInMs);
                //    Console.WriteLine($"{currentPerson.Name} done his work for {currentPerson.DoWorkTimeInMs} ms");
                //}

                // 2550 ms
                Parallel.For(0, list.Count, (i) =>
                {
                    var currentPerson = list[i];
                    Thread.Sleep(currentPerson.DoWorkTimeInMs);
                    Console.WriteLine($"{currentPerson.Name} done his work for {currentPerson.DoWorkTimeInMs} ms");
                });
                watch.Stop();

                Console.WriteLine(watch.Elapsed.TotalMilliseconds);

                //Parallel.For(0, list.Count, (i) =>
                //{
                //    var currentPerson = list[i];
                //    Thread.Sleep(currentPerson.DoWorkTimeInMs);
                //    Console.WriteLine($"{currentPerson.Name} done his work for {currentPerson.DoWorkTimeInMs} ms");
                //});
            }

            if (false)
            {
                var list = new List<Person>()
                {
                    new Person("John", 12, 1000),
                    new Person("Ann", 21, 2000),
                    new Person("Bob", 31, 2500),
                    new Person("Jake", 42, 400),
                };

                Parallel.ForEach(list, currentPerson =>
                {
                    Thread.Sleep(currentPerson.DoWorkTimeInMs);
                    Console.WriteLine($"{currentPerson.Name} done his work for {currentPerson.DoWorkTimeInMs} ms");
                });
            }

            if (false)
            {
                var people = new List<Person>()
                {
                    new Person("John", 12, 1000),
                    new Person("Ann", 21, 2000),
                    new Person("Bob", 31, 2500),
                    new Person("Jake", 42, 400),
                };

                var adults = people
                    .AsParallel()
                    .Where(p =>
                    {
                        Console.WriteLine(p.Name);
                        return p.Age >= 18;
                    })
                    // Run Parallel
                    .ToList();

                foreach (var person in adults)
                {
                    Console.WriteLine(person);
                }
            }

            if (false)
            {
                int[] arr = new int[100000];

                var watch = new Stopwatch();
                watch.Start();
                // 3,6999 ms
                //for (int i = 0; i < arr.Count(); i++)
                //{
                //    arr[i] = 123;
                //}

                // 32,2696 ms
                Parallel.For(0, arr.Count(), i =>
                {
                    arr[i] = 123;
                });
                watch.Stop();

                Console.WriteLine(watch.Elapsed.TotalMilliseconds);
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

        public static void DoSomethingBigAsync(ref bool canceled)
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