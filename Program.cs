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
            Queue<int> temp;
        OS_Printing:
            Console.Clear();
            Console.WriteLine();
            lock (q) temp = q;
            lock (temp)
                foreach (int item in temp)
                {
                    Console.Write(" " + item.ToString());
                    if (item < 10) Console.Write(" ");
                }
            Console.WriteLine();
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("_");
            Console.WriteLine("\n\n Производитель 1    Производитель 2    Производитель 3    Потребитель 1    Потребитель 2");
            Console.WriteLine(" +");
            await Task.Delay(500);
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
