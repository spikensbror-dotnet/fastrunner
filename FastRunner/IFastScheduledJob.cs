using System;

namespace FastRunner
{
    /// <summary>
    /// Represents a scheduled job.
    /// </summary>
    public interface IFastScheduledJob
    {
        /// <summary>
        /// The job that was scheduled.
        /// </summary>
        IFastJob Job { get; }

        /// <summary>
        /// The interval at which the job will execute.
        /// </summary>
        TimeSpan Interval { get; }

        /// <summary>
        /// The last UTC time the scheduled job ran.
        /// </summary>
        DateTimeOffset LastRunTime { get; set; }

        /// <summary>
        /// Specifies if the job is currently running or not.
        /// </summary>
        bool Running { get; set; }
    }
}
