using System;

namespace FastRunner
{
    public interface IFastScheduledJob
    {
        IFastJob Job { get; }
        TimeSpan Interval { get; }
        DateTimeOffset LastRunTime { get; set; }
        bool Running { get; set; }
    }
}
