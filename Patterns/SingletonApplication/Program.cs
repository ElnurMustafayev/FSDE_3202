using System;

namespace SingletonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if(true)
            {
                DoSomething();

                //var storage = new AcademyStorage();
                var storage = AcademyStorage.Instance;

                foreach (var item in storage.GetStudents())
                {
                    Console.WriteLine(item);
                }
            }

            if(false)
            {
                var s1 = Singleton.Instance;
                s1.text = "123456789";

                var s2 = Singleton.Instance;
                Console.WriteLine(s2.text);
            }
        }

        static void DoSomething()
        {
            //var storage = new AcademyStorage();
            var storage = AcademyStorage.Instance;

            storage.AddStudent(new Student()
            {
                Name = "John",
                AvgScore = 12
            });
            storage.AddStudent(new Student()
            {
                Name = "Imran",
                AvgScore = 13
            });
            storage.AddStudent(new Student()
            {
                Name = "Ann",
                AvgScore = 100
            });
        }
    }
}
