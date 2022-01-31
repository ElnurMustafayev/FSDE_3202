using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FirstLibrary;

namespace AssemblyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if(false)
            {
                //List<Car> cars = new List<Car>()
                //{
                //    new Car("BMW m5", 300),
                //};

                //foreach (var car in cars)
                //{
                //    Console.WriteLine(car);
                //}

                var assembly = Assembly.GetExecutingAssembly();

                var types = assembly.GetTypes();

                Type type1 = typeof(Program);
                Console.WriteLine(type1);

                Type type2 = new Program().GetType();
                Console.WriteLine(type2);

                Type type3 = Activator.CreateInstance<Program>().GetType();
                Console.WriteLine(type3);
            }

            if(false)
            {
                //foreach (var method in type1.GetMethods())
                //{
                //    Console.WriteLine(method.ReturnParameter.);
                //}

                Console.Clear();

                var methods = typeof(FirstLibrary.Plane).GetMethods();

                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }

            if(false)
            {
                var files = Directory.GetFiles(@"C:\Users\e.mustafayev\Desktop\Code\FSDE_3202\System Programming\Libraries\Dlls");

                foreach (var filePath in files)
                {
                    if (filePath.EndsWith(".dll") == false)
                        continue;

                    var asembly = Assembly.LoadFile(filePath);
                    var types = from t in asembly.GetTypes()
                                where t.GetInterfaces().Contains(typeof(IEnumerable<int>))
                                select t;

                    foreach (var type in types)
                    {
                        var obj = Activator.CreateInstance(type);

                        var plane = (obj as IEnumerable<int>);

                        plane.GetEnumerator();
                    }
                }
            }
        }
    }
}
