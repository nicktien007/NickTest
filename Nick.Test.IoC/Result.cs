using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.IoC
{
    /// <summary>
    /// 回傳的結果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 該操作是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 回傳的訊息
        /// </summary>
        public string Message { get; set; }

    }
}
