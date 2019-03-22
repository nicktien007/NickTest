using System;
using System.Collections.Generic;

namespace Nick.Test.Queue
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<BaseClass> queue=new Queue<BaseClass>();
            queue.Enqueue(new Class1(){ListInts = new List<int>()
            {
                1,3,3
            }});
            queue.Enqueue(new Class2(){ListInts = new List<int>()
            {
                2,2,2
            }});
            //queue.Enqueue(new Class2());
            //queue.Enqueue(new Class1());


            //foreach (var baseClass in queue)
            //{
            //    Console.WriteLine($"baseClass.Name={baseClass.GetName()}");
            //}
            Console.WriteLine($"baseClass.Name={queue.Dequeue()}");
        }
    }

    public abstract class BaseClass
    {
        public List<int> ListInts { get; set; }
        public abstract string GetName();
    }

    class Class1:BaseClass
    {
        public override string GetName()
        {
            return "Class1";
        }
    }
    class Class2 : BaseClass
    {
        public override string GetName()
        {
            return "Class2";
        }
    }
}
