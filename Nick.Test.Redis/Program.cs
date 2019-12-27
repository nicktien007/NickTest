using System;
using System.Diagnostics;
using System.Threading;

namespace Nick.Test.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            var tt5 = new ParameterizedThreadStart(p.M2DoWrite);
            Thread t5 = new Thread(tt5);
            t5.Start(5);

            var tt6 = new ParameterizedThreadStart(p.M2DoWrite);
            Thread t6 = new Thread(tt5);
            t6.Start(6);
        }

        public void M2DoWrite(object o)
        {
            Monitor.TryEnter(this, 3000);
            try
            {
                Console.WriteLine("start-" + o);
                Thread.Sleep(5000);
                Console.WriteLine(o + "-完成");
            }
            finally
            {
                Console.WriteLine("done-" + o);
                Monitor.Exit(this);
            }
            Console.WriteLine("要跳出了");
        }
    }
}
