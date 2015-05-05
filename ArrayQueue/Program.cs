using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> sysqueue = new Queue<int>();
            Stopwatch sw= new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                //if (new Random().Next(0, 100) > 40)
                    sysqueue.Enqueue(i);
               // else
               //     sysqueue.Dequeue();
            }
            sw.Stop();

            Console.WriteLine("Sys queue" + sw.Elapsed.TotalSeconds);

            ArrayQueue<int> myqueue = new ArrayQueue<int>();
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                //if (new Random().Next(0, 100) > 40)
                    myqueue.Enqueue(i);
                //else
                //    myqueue.Dequeue();
            }
            sw.Stop();

            Console.WriteLine("my queue" + sw.Elapsed.TotalSeconds);
            Console.Read();

        }
    }
}
