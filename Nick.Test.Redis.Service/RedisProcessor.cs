using System;
using Nick.Test.Interface;

namespace Nick.Test.Redis.Service
{
    public  class RedisProcessor: IRedisHelper
    {
        public  void Print1()
        {
            Console.WriteLine("RedisProcessor.Print1");
        }
        public  void Print2()
        {
            Console.WriteLine("RedisProcessor.Print2");
        }
        public  void Print3()
        {
            Console.WriteLine("RedisProcessor.Print3");
        }
    }
}
