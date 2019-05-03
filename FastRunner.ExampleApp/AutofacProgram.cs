using Autofac;
using System;

namespace FastRunner.ExampleApp
{
    static class AutofacProgram
    {
        public static void Run(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleWriteTestJob>();
            builder.AddFastRunner();

            var otherBuilder = new ContainerBuilder();
            otherBuilder.RegisterType<OtherConsoleWriteTestJob>();
            otherBuilder.AddFastRunner();

            using (var container = builder.Build())
            using (var otherContainer = otherBuilder.Build())
            {
                container.Resolve<IFastJobScheduler>().Schedule<ConsoleWriteTestJob>(TimeSpan.FromSeconds(5));
                otherContainer.Resolve<IFastJobScheduler>().Schedule<OtherConsoleWriteTestJob>(TimeSpan.FromSeconds(1));

                Console.ReadKey(true);
            }
        }
    }
}
