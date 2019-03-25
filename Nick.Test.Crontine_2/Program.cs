using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nick.Common;

namespace Nick.Test.Crontine_2
{
    class Program
    {
        private static int loopCount = 0;
        static void Main(string[] args)
        {
            //OneThreadSynchronizationContext _ = OneThreadSynchronizationContext.Instance;
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);


            Console.WriteLine($"主線程: {Thread.CurrentThread.ManagedThreadId}");

            Crontine();

            while (true)
            {
                OneThreadSynchronizationContext.Instance.Update();

                Thread.Sleep(1);

                ++loopCount;
                if (loopCount % 10000 == 0)
                {
                    Console.WriteLine($"loop count: {loopCount}");
                }
            }
        }

        private static async void Crontine()
        {
            await WaitTimeAsync(5000);
            Console.WriteLine($"當前線程: {Thread.CurrentThread.ManagedThreadId}, WaitTimeAsync finsih loopCount的值是: {loopCount}");

            await WaitTimeAsync(4000);
            Console.WriteLine($"當前線程: {Thread.CurrentThread.ManagedThreadId}, WaitTimeAsync finsih loopCount的值是: {loopCount}");

            await WaitTimeAsync(3000);
            Console.WriteLine($"當前線程: {Thread.CurrentThread.ManagedThreadId}, WaitTimeAsync finsih loopCount的值是: {loopCount}");
        }

        private static Task WaitTimeAsync(int waitTime)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Thread thread = new Thread(() => WaitTime(waitTime, tcs));
            thread.Start();
            return tcs.Task;
        }

        /// <summary>
        /// 在另外的線程等待
        /// </summary>
        private static void WaitTime(int waitTime, TaskCompletionSource<bool> tcs)
        {
            Thread.Sleep(waitTime);

            // 將tcs扔回主線程執行
            //OneThreadSynchronizationContext.Instance.Post(o => tcs.SetResult(true), null);
            tcs.SetResult(true);
        }
    }
}
