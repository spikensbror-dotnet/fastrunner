using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FastRunner
{
    class FastJobThread : IDisposable
    {
        private readonly IFastJobScheduler scheduler;
        private readonly Thread thread;

        private bool ShouldStop { get; set; }

        public FastJobThread(IFastJobScheduler scheduler)
        {
            this.scheduler = scheduler;
            this.thread = new Thread(new ThreadStart(this.Main));
            this.thread.Start();
        }

        private void Main()
        {
            while (!this.ShouldStop)
            {
                var scheduledJobsToRun = this.scheduler.Get()
                    .Where(sj => sj.ShouldRun(DateTimeOffset.UtcNow))
                    .ToArray();

                foreach (var scheduledJob in scheduledJobsToRun)
                {
                    Task.Run(async () =>
                    {
                        scheduledJob.Running = true;

                        await scheduledJob.Job.Execute();

                        scheduledJob.Running = false;
                    });

                    scheduledJob.LastRunTime = DateTimeOffset.UtcNow;
                }

                Thread.Sleep(50);
            }

            this.ShouldStop = false;
        }

        public void Dispose()
        {
            this.ShouldStop = true;
            this.thread.Join();
        }
    }
}
