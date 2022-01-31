using System;
using System.Collections;
using System.Collections.Generic;
using BaseLibrary;

namespace FirstLibrary
{
    public class Plane : Transport, IEnumerable<int>
    {
        public Plane(string name, double speed) : base(name, speed)
        {

        }

        public void Fly()
        {
            Console.WriteLine($"Plane {name} flies...");
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
