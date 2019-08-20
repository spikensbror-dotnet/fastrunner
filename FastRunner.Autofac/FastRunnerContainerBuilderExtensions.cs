using FastRunner;
using FastRunner.Autofac;
using System.Reflection;

namespace Autofac
{
    /// <summary>
    /// Extension methods for registering FastRunner with Autofac.
    /// </summary>
    public static class FastRunnerContainerBuilderExtensions
    {
        /// <summary>
        /// Adds a FastRunner scheduler to the specified builder and registers it
        /// for startup when the container is built.
        /// </summary>
        /// <param name="builder">The builder to add FastRunner to.</param>
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

        /// <summary>
        /// Registers <see cref="IFastJob"/> implementations in the given assemblies.
        /// </summary>
        /// <param name="builder">The builder to register fast jobs for.</param>
        /// <param name="assemblies">The assemblies to discover fast job implementations in.</param>
        public static void RegisterFastJobs(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsAssignableTo<IFastJob>())
                .AsSelf()
                .As<IFastJob>()
                .SingleInstance();
        }
    }
}
