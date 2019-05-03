﻿using FastRunner;
using FastRunner.Autofac;

namespace Autofac
{
    public static class FastRunnerContainerBuilderExtensions
    {
        public static void AddFastRunner(this ContainerBuilder builder)
        {
            builder.Register(c => FastJobs.CreateScheduler(new FastAutofacActivator(c.Resolve<ILifetimeScope>())))
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<JobStartup>()
                .AsSelf()
                .SingleInstance();

            // Resolve JobStartup so that it lives along with the container.
            builder.RegisterBuildCallback(c => c.Resolve<JobStartup>());
        }
    }
}
