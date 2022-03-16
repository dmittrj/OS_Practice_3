using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_Practice_3
{
    class OS_Manufacturer : OS_Threader
    {
        //public Thread thread;
        int OS_ManifacturerNumber;
        public Queue<int> mq = new();
        Random random = new();
        bool OS_isSleeping;

        public OS_Manufacturer(int num)
        {
            OS_ManifacturerNumber = num;
            OS_isSleeping = false;
            ShutDown = false;
            thread = new Thread(OS_Manufacte);
            thread.Start();
        }
        private void OS_Manufacte()
        {
        OS_Mnf:
            if (OS_isSleeping)
            {
                if (Program.q.Count <= 80) OS_isSleeping = false;
            }
            else
            {
                int w = random.Next(1, 100);
                lock (Program.q)
                    Program.q.Enqueue(w);
                lock (mq)
                    mq.Enqueue(w);
                //Console.WriteLine("Производитель [" + OS_ManifacturerNumber.ToString() + "]: добавлено " + w.ToString());
                if (Program.q.Count >= 100)
                {
                    OS_isSleeping = true;
                    //Console.WriteLine("Производитель [" + OS_ManifacturerNumber.ToString() + "]: уснул");
                }
            }
            try
            {
                Thread.Sleep(500);
            } catch
            {
                return;
            }
            goto OS_Mnf;
        }
    }
}
