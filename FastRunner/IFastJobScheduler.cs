using System;

namespace FastRunner
{
    /// <summary>
    /// Manages the schedule for a specific FastRunner instance.
    /// </summary>
    public interface IFastJobScheduler
    {
        /// <summary>
        /// Schedules the specified job to run on the given interval. If the interval hits
        /// while the job is still running, it will simply be delayed until it is finished.
        /// </summary>
        /// <typeparam name="TJob">The type of the job to schedule.</typeparam>
        /// <param name="interval">The interval at which the job should recur.</param>
        void Schedule<TJob>(TimeSpan interval) where TJob : IFastJob;

        /// <summary>
        /// Scheduled the provided job on the given interval. If interval hits while the
        /// job is still running, it will simply be delayed until the current execution
        /// finishes.
        /// </summary>
        /// <param name="job">The job to schedule.</param>
        /// <param name="interval">The interval at which the job should recur.</param>
        void Schedule(IFastJob job, TimeSpan interval);

        /// <summary>
        /// Gets the scheduled jobs that have been scheduled by the scheduler.
        /// </summary>
        /// <returns>The scheduled jobs of the scheduler.</returns>
        IFastScheduledJob[] Get();
    }
}
