using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MyLinq
{
    public static class MyEnumerable
    {
        public static int MyCount(this IEnumerable<int> collection)
        {
            int counter = 0;
            foreach (var item in collection)
            {
                counter++;
            }

            return counter;
        }

        //public static string Capitalize(this string name)
        //{
        //    return $"{name[0]}".ToUpper() + name.Substring(1);
        //}
    }
}
