using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PararellProgramming
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person SetAge(int age)
        {
            this.Age = age;
            return this;
        }

        public Person SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Age} years old";
        }
    }
}
