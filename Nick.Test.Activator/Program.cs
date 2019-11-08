using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Nick.Test.Activator
{
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass(){Age = 1,Name = "FirstName"};

            //var t = myClass.GetType();
            var t = typeof(MyClass);

            Dictionary<object,int> qoo=new Dictionary<object, int>();

            var t1 = System.Activator.CreateInstance(t);
            var t1GetHashCode1 = t1.GetHashCode();

            var t2 = System.Activator.CreateInstance(t);
            var t2GetHashCode2 = t2.GetHashCode();

            qoo.Add(t1, t1GetHashCode1);
            qoo.Add(t2, t2GetHashCode2);

            var qr1 = qoo[t1];
            var qr2 = qoo[t2];
        }
    }

    public class MyClass
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
