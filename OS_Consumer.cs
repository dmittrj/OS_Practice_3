using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_Practice_3
{
    class OS_Consumer : OS_Threader
    {
        //public Thread thread;
        int OS_ConsumerNumber;
        public Queue<int> cq = new();

        public OS_Consumer(int num)
        {
            OS_ConsumerNumber = num;
            ConsumersAlive = 2;
            thread = new Thread(OS_Consume);
            thread.Start();
        }
        private void OS_Consume()
        {
        OS_Cns:
            lock (Program.q) {
                if (Program.q.Count > 0)
                {
                    lock (cq)
                        cq.Enqueue(Program.q.Dequeue());
                } else if (ShutDown)
                {
                    ConsumersAlive--;
                    if (ConsumersAlive == 0)
                    {
                        Console.WriteLine("\n\n Подождите, программа сейчас завершится\n\n");
                        Thread.Sleep(3000);
                    }
                    return;
                }
            }
            Thread.Sleep(500);
            goto OS_Cns;
        }
    }
}
