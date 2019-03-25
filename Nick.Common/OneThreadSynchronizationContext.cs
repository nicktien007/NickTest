using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nick.Common
{
    public class OneThreadSynchronizationContext : SynchronizationContext
    {
        public static OneThreadSynchronizationContext Instance { get; } = new OneThreadSynchronizationContext();

        private readonly int mainThreadId = Thread.CurrentThread.ManagedThreadId;

        // 線程同步隊列,發送接收socket回調都放到該隊列,由poll線程統一執行
        private readonly ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();

        private Action a;

        public void Update()
        {
            while (true)
            {
                if (!this.queue.TryDequeue(out a))
                {
                    return;
                }
                a();
            }
        }

        public override void Post(SendOrPostCallback callback, object state)
        {
            if (Thread.CurrentThread.ManagedThreadId == this.mainThreadId)
            {
                callback(state);
                return;
            }

            this.queue.Enqueue(() => { callback(state); });
        }
    }
}
