using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLibrary;

namespace AssemblyApplication
{
    public class Car : Transport
    {
        public Car(string name, double speed) : base(name, speed) { }
    }
}
