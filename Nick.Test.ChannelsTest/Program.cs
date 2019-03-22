using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Channels;


namespace Nick.Test.ChannelsTest
{
    class Program
    {
        public static void Measure(string title, Action<int, bool> test, int count, int warmupCount = 1)
        {
            test(warmupCount, true); // Warmup
            var sw = new Stopwatch();
            GC.Collect();
            sw.Start();
            test(count, false);
            sw.Stop();
            Console.WriteLine($"{title}: {sw.Elapsed.TotalMilliseconds:0.000}ms");
        }

        static async void AddOne(WritableChannel<int> output, ReadableChannel<int> input)
        {
            await output.WriteAsync(1 + await input.ReadAsync());
        }

        static async Task<int> AddOne(Task<int> input)
        {
            var result = 1 + await input;
            await Task.Yield();
            return result;
        }
        static void Main(string[] args)
        {
            if (!int.TryParse(args.FirstOrDefault(), out var maxCount))
                maxCount = 1000000;
            Measure($"Sending {maxCount} messages (channels)", (count, isWarmup) => {
                var firstChannel = Channel.CreateUnbuffered<int>();
                var output = firstChannel;
                for (var i = 0; i < count; i++)
                {
                    var input = Channel.CreateUnbuffered<int>();
                    AddOne(output.Out, input.In);
                    output = input;
                }
                output.Out.WriteAsync(0);
                if (!isWarmup)
                    Console.WriteLine(firstChannel.In.ReadAsync().Result);
            }, maxCount);
            Measure($"Sending {maxCount} messages (Task<int>)", (count, isWarmup) => {
                var tcs = new TaskCompletionSource<int>();
                var firstTask = AddOne(tcs.Task);
                var output = firstTask;
                for (var i = 0; i < count; i++)
                {
                    var input = AddOne(output);
                    output = input;
                }
                tcs.SetResult(-1);
                if (!isWarmup)
                    Console.WriteLine(output.Result);
            }, maxCount);
        }
    }
}
