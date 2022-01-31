using System;

namespace UnsafeApplication
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            if(false)
            {
                int number = 100;
                int* intPtr = &number;

                intPtr += 1;

                Console.WriteLine(*intPtr);
            }
            
            if(false)
            {
                int[] arr = new int[] { 10, 11, 12 };

                fixed (int* intPtr = &arr[0])
                {
                    int* p = intPtr;
                    Console.WriteLine(*p);
                    p += 1;
                    Console.WriteLine(*p);
                    p += 1;
                    Console.WriteLine(*p);
                }
            }

            if(true)
            {
                unsafe
                {
                    int number = 100;
                    int* intPtr = &number;

                    intPtr += 1;

                    Console.WriteLine(*intPtr);
                }
            }
        }
    }
}