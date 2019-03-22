using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test
{
    interface IClassA
    {
        string Name { get; set; }
    }


    interface IClassAAAAA
    {
        void GetData();
    }

    abstract class ClassAAAAA
    {
        public abstract void GetData();
    }

    class ClassBBBB
    {
        public void GetData()
        {

        }
    }
}
