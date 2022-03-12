using System;
using System.Collections;
using System.Collections.Generic;

namespace OS_Practice_3
{
    class Program
    {
        public static Queue<int> q = new();
        static void Main(string[] args)
        {
            object[] f =
            {
                new OS_Manufacturer(1),
                new OS_Manufacturer(2),
                new OS_Manufacturer(3),
                new OS_Consumer(1),
                new OS_Consumer(2)
            };
        }
    }
}
