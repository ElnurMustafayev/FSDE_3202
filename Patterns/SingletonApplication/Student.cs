using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApplication
{
    public class Student
    {
        public string Name { get; set; }
        public int AvgScore { get; set; }

        public override string ToString() => $"{Name}: {AvgScore}";
    }
}
