using System;
using System.Collections.Generic;

namespace FastRunner
{
    class InMemoryJobScheduler : IFastJobScheduler
    {
        private readonly List<IFastScheduledJob> scheduledJobs;
        private readonly IFastJobActivator jobActivator;

        public InMemoryJobScheduler(IFastJobActivator jobActivator)
        {
            this.scheduledJobs = new List<IFastScheduledJob>();
            this.jobActivator = jobActivator;
        }

        public IFastScheduledJob[] Get()
        {
            return this.scheduledJobs.ToArray();
        }

        public void Schedule<TJob>(TimeSpan interval) where TJob : IFastJob
        {
            this.Schedule(this.jobActivator.Activate(typeof(TJob)), interval);
        }

        public void Schedule(IFastJob job, TimeSpan interval)
        {
            this.scheduledJobs.Add(new ScheduledJob(job, interval));
        }

        class ScheduledJob : IFastScheduledJob
        {
            public IFastJob Job { get; }
            public TimeSpan Interval { get; }

            public DateTimeOffset LastRunTime { get; set; }
            public bool Running { get; set; }

            public ScheduledJob(IFastJob job, TimeSpan interval)
            {
                this.Job = job;
                this.Interval = interval;

                this.LastRunTime = DateTimeOffset.MinValue;
                this.Running = false;
            }
        }
    }
}
