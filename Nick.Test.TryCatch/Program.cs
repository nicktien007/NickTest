using System;

namespace Nick.Test.TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {


            TryAction.TryExec(Qoo);


            TryAction.TryExec(() => {
                // 要執行的操作
            });



            TryAction.TryExec(()=>{
                    // 要執行的操作
            },
            (ex) => {
                // 出錯後要執行的操作
            });
        }

        static void Qoo()
        {
            //Console.WriteLine("Hello World!");
            string q = null;

            var l=q.Length;
        }
    }
}
