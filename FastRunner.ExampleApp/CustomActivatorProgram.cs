using System;

namespace FastRunner.ExampleApp
{
    static class CustomActivatorProgram
    {
        public static void Run(string[] args)
        {
            FastJobs.DefaultJobActivator = new DefaultJobActivator();

            var scheduler = FastJobs.CreateScheduler();
            scheduler.Schedule<ConsoleWriteTestJob>(TimeSpan.FromSeconds(5));

            var otherScheduler = FastJobs.CreateScheduler(new OtherJobActivator());
            otherScheduler.Schedule<OtherConsoleWriteTestJob>(TimeSpan.FromSeconds(1));

            using (FastJobs.Run(scheduler))
            using (FastJobs.Run(otherScheduler))
            {
                Console.ReadKey(true);
            }
        }

        class DefaultJobActivator : IFastJobActivator
        {
            IFastJob IFastJobActivator.Activate(Type jobType)
            {
                Console.WriteLine($"Activated fast running job {jobType.Name} from my default job activator!");

                return (IFastJob)Activator.CreateInstance(jobType);
            }
        }

        class OtherJobActivator : IFastJobActivator
        {
            IFastJob IFastJobActivator.Activate(Type jobType)
            {
                Console.WriteLine($"Activated fast running job {jobType.Name} from my other job activator!");

                return (IFastJob)Activator.CreateInstance(jobType);
            }
        }
    }
}
