using System;

namespace FastRunner
{
    /// <summary>
    /// FastRunner is a job scheduler made specifically for fast-running
    /// transient asynchronous jobs.
    /// </summary>
    public static class FastJobs
    {
        /// <summary>
        /// The default job activator used by schedulers created by FastRunner.
        /// </summary>
        public static IFastJobActivator DefaultJobActivator { get; set; }

        static FastJobs()
        {
            DefaultJobActivator = new DefaultJobActivator();
        }

        /// <summary>
        /// Creates a new FastRunner job scheduler.
        /// </summary>
        /// <param name="jobActivator">A specific job activator to use for the scheduler instance or null to use the default.</param>
        /// <returns></returns>
        public static IFastJobScheduler CreateScheduler(IFastJobActivator jobActivator = null)
        {
            return new InMemoryJobScheduler(jobActivator ?? DefaultJobActivator);
        }

        /// <summary>
        /// Runs the scheduler on a new thread that is stopped when the returned handle is disposed.
        /// </summary>
        /// <param name="scheduler">The job scheduler to run.</param>
        /// <returns>A handle that stops the scheduler when disposed.</returns>
        public static IDisposable Run(IFastJobScheduler scheduler)
        {
            return new FastJobThread(scheduler);
        }
    }
}
