using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_Practice_3
{
    class OS_Consumer
    {
        Thread thread;
        int OS_ConsumerNumber;

        public OS_Consumer(int num)
        {
            OS_ConsumerNumber = num;
            thread = new Thread(OS_Consume);
            thread.Start();
        }
        private void OS_Consume()
        {
        OS_Cns:
            lock (Program.q) {
                if (Program.q.Count > 0)
                {
                    Console.WriteLine("  Потребитель [" + OS_ConsumerNumber.ToString() + "]: снято " + Program.q.Dequeue().ToString());
                }
            }
            Thread.Sleep(500);
            goto OS_Cns;
        }
    }
}
