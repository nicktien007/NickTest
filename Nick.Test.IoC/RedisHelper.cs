using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nick.Test.Interface;

namespace Nick.Test.IoC
{
    /// <summary>
    /// 這是RedisHelper的Class標題
    /// </summary>
    public class RedisHelper
    {
        private IRedisHelper _processor;
        public RedisHelper(IRedisHelper redisHelper)
        {
            _processor = redisHelper;
        }

        //public void Print1()
        //{
        //    _processor.Print1();
        //}
        //public void Print2()
        //{
        //    _processor.Print2();
        //}
        //public void Print3()
        //{
        //    _processor.Print3();
        //}

        /// <summary>
        /// GetInstance
        /// </summary>
        /// <returns></returns>
        public IRedisHelper GetInstance()
        {
            return _processor;
        }

        /// <summary>
        /// 這是一個測試方法1
        /// </summary>
        /// <param name="id">集合的ID</param>
        /// <returns>查詢的集合</returns>
        public List<string> GetListByTest1(string id)
        {
            return  new List<string>();
        }

        /// <summary>
        /// 這是一個測試方法2
        /// </summary>
        /// <param name="id">集合的ID</param>
        /// <returns>查詢的集合</returns>
        public Result GetListByTest2(string id)
        {
            return new Result();
        }
    }
}
