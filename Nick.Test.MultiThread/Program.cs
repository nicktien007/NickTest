using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nick.Test.MultiThread
{
    /// <summary>
    /// Effective C# - 作法37：使用執行緒區集取代建立執行緒
    /// </summary>
    class Program
    {
        const int LowerBound = 1;
        const int UpperBound = 100;
        private const int NumThreads = 10;

        static async Task Main(string[] args)
        {
            ThreadPool.SetMinThreads(200, 200);

            Console.WriteLine($"OneThread:{OneThread()}");
            Console.WriteLine($"TaskLibrary:{await TaskLibrary(NumThreads)}");
            Console.WriteLine($"TaskLibraryStartNew:{await TaskLibraryFactoryStartNew(NumThreads)}");
            Console.WriteLine($"TaskLibraryAsync:{await TaskLibraryAsync(NumThreads)}");
            Console.WriteLine($"ThreadPoolThreads:{ThreadPoolThreads(NumThreads)}");
            Console.WriteLine($"ManualThreads:{ManualThreads(NumThreads)}");

            //Console.WriteLine($"ThreadPoolThreads:{ThreadPoolThreads1(NumThreads)}");
        }

        private static double OneThread()
        {
            Stopwatch start = new Stopwatch();
            double answer = 0;
            start.Start();

            for (int i = LowerBound; i < UpperBound; i++)
            {
                //answer = Hero.FindRoot(i);
                answer = Hero.GetContentLength();
                //Console.WriteLine($"OneThread調用的Thread Id ={Thread.CurrentThread.ManagedThreadId}, answer={answer}");
            }

            start.Stop();
            //Console.WriteLine($"answer={answer}");
            return start.ElapsedMilliseconds;
        }

        private static async Task<double> TaskLibrary(int numTasks)
        {
            var itemsPerTask = (UpperBound - LowerBound) / numTasks + 1;
            double answer=0;
            List<Task> tasks = new List<Task>(numTasks);
            Stopwatch start = new Stopwatch();
            start.Start();

            for (int i = LowerBound; i < UpperBound; i += itemsPerTask)
            {
                tasks.Add(Task.Run(() => {
                    for (int j = i; j < i + itemsPerTask; j++)
                    {
                        answer = Hero.FindRoot(j);
                        //answer = Hero.GetContentLength();
                        //Console.WriteLine($"TaskLibrary調用的Thread Id ={Thread.CurrentThread.ManagedThreadId}, answer={answer}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
            start.Stop();
            //Console.WriteLine($"answer={answer}");
            return start.ElapsedMilliseconds;
        }

        private static async Task<double> TaskLibraryAsync(int numTasks)
        {
            var itemsPerTask = (UpperBound - LowerBound) / numTasks + 1;
            double answer = 0;
            List<Task> tasks = new List<Task>(numTasks);
            Stopwatch start = new Stopwatch();
            start.Start();

            for (int i = LowerBound; i < UpperBound; i += itemsPerTask)
            {
                tasks.Add(Task.Run(async () => {
                    for (int j = i; j < i + itemsPerTask; j++)
                    {
                        answer =await Hero.FindRootAsync(j);
                        //answer = Hero.GetContentLength();
                        //Console.WriteLine($"TaskLibraryAsync調用的Thread Id ={Thread.CurrentThread.ManagedThreadId}, answer={answer}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
            start.Stop();
            //Console.WriteLine($"answer={answer}");
            return start.ElapsedMilliseconds;
        }

        private static async Task<double> TaskLibraryFactoryStartNew(int numTasks)
        {
            var itemsPerTask = (UpperBound - LowerBound) / numTasks + 1;
            double answer = 0;
            List<Task> tasks = new List<Task>(numTasks);
            Stopwatch start = new Stopwatch();
            start.Start();

            for (int i = LowerBound; i < UpperBound; i += itemsPerTask)
            {
                tasks.Add(Task.Factory.StartNew(() => {
                    for (int j = i; j < i + itemsPerTask; j++)
                    {
                        answer = Hero.FindRoot(j);
                        //answer = Hero.GetContentLength();
                        //Console.WriteLine($"TaskLibraryFactoryStartNew調用的Thread Id ={Thread.CurrentThread.ManagedThreadId}, answer={answer}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
            start.Stop();
            //Console.WriteLine($"answer={answer}");
            return start.ElapsedMilliseconds;
        }

        private static double ThreadPoolThreads(int numThreads)
        {
            Stopwatch start = new Stopwatch();

            using (AutoResetEvent e = new AutoResetEvent(false))
            {
                int workerThreads = numThreads;
                double answer = 0;
                start.Start();

                for (int thread = 0; thread < numThreads; thread++)
                {
                    var thread1 = thread;
                    ThreadPool.QueueUserWorkItem(x => {
                        for (int i = LowerBound; i < UpperBound; i++)
                        {
                            if (i % numThreads == thread1)
                            {
                                answer = Hero.FindRoot(i);
                                //answer = Hero.GetContentLength();
                            }
                        }

                        if (Interlocked.Decrement(ref workerThreads) == 0)
                        {
                            e.Set();
                        }
                    });
                }

                
                e.WaitOne();
                //Console.WriteLine($"answer={answer}");
                start.Stop();
                return start.ElapsedMilliseconds;
            }
        }

        private static double ManualThreads(int numThreads)
        {
            Stopwatch start = new Stopwatch();

            using (AutoResetEvent e = new AutoResetEvent(false))
            {
                int workerThreads = numThreads;
                double answer = 0;
                start.Start();

                for (int thread = 0; thread < numThreads; thread++)
                {
                    var thread1 = thread;
                    Thread t = new Thread(() =>
                    {
                        for (int i = LowerBound; i < UpperBound; i++)
                        {
                            if (i % numThreads == thread1)
                            {
                                answer = Hero.FindRoot(i);
                                //answer = Hero.GetContentLength();
                            }
                        }

                        if (Interlocked.Decrement(ref workerThreads) == 0)
                        {
                            e.Set();
                        }
                    });

                    t.Start();
                }
                e.WaitOne();
                start.Stop();
                //Console.WriteLine($"answer={answer}");
                return start.ElapsedMilliseconds;
            }
        }

        class Hero
        {
            public static double FindRoot(double number)
            {
                Thread.Sleep(10);

                double previousError = double.MaxValue;
                double guess = 1;
                double error = Math.Abs(guess * guess - number);

                while (previousError / error > 1.000001)
                {
                    guess = (number / guess + guess) / 2.0;
                    previousError = error;
                    error = Math.Abs(guess * guess - number);
                }
                
                return guess;
            }

            public static async Task<double> FindRootAsync(double number)
            {
                //await Task.Delay(10);
                double previousError = double.MaxValue;
                double guess = 1;
                double error = Math.Abs(guess * guess - number);

                while (previousError / error > 1.000001)
                {
                    guess = (number / guess + guess) / 2.0;
                    previousError = error;
                    error = Math.Abs(guess * guess - number);
                }

                return guess;
            }

            public static int GetContentLength()
            {
                Thread.Sleep(100);

                var client = new HttpClient();
                var url = "https://www.google.com";
                //return client.GetStringAsync(url).Result.Length;
                return 0;
            }
        }
    }
}
