using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace Nick.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            
            

            while (true)
            {
                Thread.Sleep(100);
                ShowHello();
            }



            Console.ReadKey();

        }

        private static void ShowHello()
        {
            Console.WriteLine("打印我");
          
        }
    }
}
