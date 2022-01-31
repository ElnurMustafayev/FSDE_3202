using System;
using System.IO;

namespace Memory_management
{
    class Test : IDisposable
    {
        Stream stream;

        public Test()
        {
            this.stream = new FileStream("text.txt", FileMode.OpenOrCreate);
        }

        ~ Test()
        {
            Console.WriteLine("Test class deleted");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if(false)
            {
                CheckFinalizer();

                GC.Collect();
                int number = 100;

                Console.WriteLine(GC.GetTotalMemory(true));
                Console.WriteLine(GC.MaxGeneration);
                Console.WriteLine(GC.GetGeneration(number));
            }

            if(true)
            {
                CheckFinalizer();
            }
        }

        static void CheckFinalizer()
        {
            /*
            Test test = null;
            try
            {
                test = new Test();
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                test?.Dispose();
            }
            */

            using Test test = new Test();

            Console.WriteLine("Test");
        }
    }
}
