using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nick.Common;
using Nick.Test.Redis.Service;

namespace Nick.Test.IoC
{
    class Program
    {
        static void Main(string[] args)
        {
            //RedisHelper.Print1();
            //RedisHelper.Print2();
            //IContainer middleCompany = MiddleCompany();
            //RedisHelper helper = middleCompany.Resolve<RedisHelper>();

            HelperCollection.RedisHelper.Print1();


      

        }

        
    }
}
