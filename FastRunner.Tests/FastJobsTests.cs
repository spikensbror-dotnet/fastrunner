using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastRunner.Tests
{
    [TestClass]
    public class FastJobTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            TestJob.Invokations = 0;
        }

        [TestMethod]
        public void ShouldBeAbleToScheduleAndRunJobs()
        {
            var scheduler = FastJobs.CreateScheduler();
            scheduler.Schedule<TestJob>(TimeSpan.FromSeconds(5));

            using (FastJobs.Run(scheduler))
            {
                Thread.Sleep(1000);
            }

            Assert.AreEqual(1, TestJob.Invokations);
        }

        [TestMethod]
        public void ShouldBeAbleToScheduleAndRunJobsViaAutofac()
        {
            var builder = new ContainerBuilder();

            builder.AddFastRunner();
            builder.RegisterFastJobs(Assembly.GetExecutingAssembly());

            using (var container = builder.Build())
            {
                var scheduler = container.Resolve<IFastJobScheduler>();
                scheduler.Schedule<TestJob>(TimeSpan.FromSeconds(5));

                Thread.Sleep(1000);
            }

            Assert.AreEqual(1, TestJob.Invokations);
        }
    }

    class TestJob : IFastJob
    {
        public static int Invokations { get; set; }

        public async Task Execute()
        {
            Invokations++;
        }
    }
}
