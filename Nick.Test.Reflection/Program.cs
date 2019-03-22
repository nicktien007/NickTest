using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Nick.Test.Reflection.Test;

namespace Nick.Test.Reflection
{
    /// <summary>
    /// 測試 反射
    /// </summary>
    class Program
    {
        private static readonly string AssemblyName = "Nick.Test.Reflection";
        

        static void Main(string[] args)
        {
            var className = $"{AssemblyName}.Test.Class1";
            var class1 = (Class1)Assembly.Load(AssemblyName).CreateInstance(className);

            var class2Name = $"{AssemblyName}.Class2";
            var class2 = (Class2)Assembly.Load(AssemblyName).CreateInstance(class2Name);

            Console.WriteLine(class2?.Name);
            Console.WriteLine(class1?.Name);
        }
    }
}
