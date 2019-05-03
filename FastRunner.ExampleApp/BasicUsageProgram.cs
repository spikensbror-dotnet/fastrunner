using System;

namespace FastRunner.ExampleApp
{
    static class BasicUsageProgram
    {
        public static void Run(string[] args)
        {
            var scheduler = FastJobs.CreateScheduler();
            scheduler.Schedule<ConsoleWriteTestJob>(TimeSpan.FromSeconds(5));

            var otherScheduler = FastJobs.CreateScheduler();
            otherScheduler.Schedule<OtherConsoleWriteTestJob>(TimeSpan.FromSeconds(1));

            using (FastJobs.Run(scheduler))
            using (FastJobs.Run(otherScheduler))
            {
                Console.ReadKey(true);
            }
        }
    }
}
