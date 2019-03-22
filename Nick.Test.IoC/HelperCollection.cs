using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nick.Test.Interface;
using Nick.Test.Redis.Service;

namespace Nick.Test.IoC
{
    public static class HelperCollection
    {
        static HelperCollection()
        {
            IContainer middleCompany = MiddleCompany();
            RedisHelper = middleCompany.Resolve<RedisHelper>().GetInstance();
        }

        public static IRedisHelper RedisHelper { get; }

        /// <summary>
        /// 仲介公司
        /// </summary>
        /// <returns></returns>
        private static IContainer MiddleCompany()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<RedisHelper>();
            //builder.RegisterType<RedisProcessor>().As<IRedisHelper>();
            builder.RegisterType<RedisProcessor2>().As<IRedisHelper>();

            return builder.Build();
        }
    }


   
}
