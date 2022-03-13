using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OS_Practice_3
{
    class Program
    {
        public static Queue<int> q = new();

        public async static void OS_Print()
        {
            OS_Printing:
            Console.Clear();
            Console.WriteLine();
            foreach (int item in q)
            {
                Console.Write(" " + item.ToString());
            }
            Console.WriteLine("\n________________________________");
            await Task.Delay(1000);
            goto OS_Printing;
        }

        static void Main(string[] args)
        {
            Thread printer = new Thread(OS_Print);
            object[] f =
            {
                new OS_Manufacturer(1),
                new OS_Manufacturer(2),
                new OS_Manufacturer(3),
                new OS_Consumer(1),
                new OS_Consumer(2)
            };
            printer.Start();
        }
    }
}
