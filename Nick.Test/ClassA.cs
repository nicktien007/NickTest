using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test
{

    [System.Runtime.InteropServices.Guid("EB2EF712-5669-4626-8D99-EB14C3838724")]
    public class ClassA: IClassA
    {
        private ClassB classB;

        private static int _count;

        
        public ClassA()
        {
            //if (classB==null)
            //{
            //    classB = new ClassB();
            //}
            classB = ClassB.Instance;
            
            _count++;

            
        }

        public  int GetClassBCount()
        {
            return classB.Count;
        }

        public  int GetClassACount()
        {
            return _count;
        }

        public string Name { get; set; }
    }
}
