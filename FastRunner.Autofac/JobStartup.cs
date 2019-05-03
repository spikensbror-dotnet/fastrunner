using FastRunner;
using System;

namespace Autofac
{
    class JobStartup : IDisposable
    {
        private readonly IFastJobScheduler scheduler;
        private readonly IDisposable disposable;

        public JobStartup(IFastJobScheduler scheduler)
        {
            this.scheduler = scheduler;
            this.disposable = FastJobs.Run(scheduler);
        }

        public void Dispose()
        {
            using (this.disposable)
            {
                //
            }
        }
    }
}
