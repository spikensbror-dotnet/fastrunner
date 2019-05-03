﻿using System;

namespace FastRunner
{
    public static class IFastScheduledJobExtensions
    {
        public static bool ShouldRun(this IFastScheduledJob job, DateTimeOffset utcNow)
        {
            return !job.Running &&
                (job.LastRunTime == DateTimeOffset.MinValue ||
                utcNow - job.LastRunTime > job.Interval);
        }
    }
}
