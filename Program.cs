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
            Console.WriteLine("\n\n q - остановить производителей");
            await Task.Delay(500);
            if (OS_Threader.ConsumersAlive == 0) return;
            goto OS_Printing;
        }

        static void Main(string[] args)
        {
            Thread printer = new(OS_Print);
            OS_Threader[] f =
            {
                new OS_Manufacturer(1),
                new OS_Manufacturer(2),
                new OS_Manufacturer(3),
                new OS_Consumer(1),
                new OS_Consumer(2)
            };
            printer.Start();
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Q)
            {
                for (int i = 0; i < 3; i++)
                {
                    f[i].thread.Interrupt();
                    OS_Threader.ShutDown = true;
                }
            }
        }
    }
}
