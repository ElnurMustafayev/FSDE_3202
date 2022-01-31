using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public abstract class Transport
    {
        protected string name;
        protected double speed;

        protected Transport(string name, double speed)
        {
            this.name = name;
            this.speed = speed;
        }
    }
}
