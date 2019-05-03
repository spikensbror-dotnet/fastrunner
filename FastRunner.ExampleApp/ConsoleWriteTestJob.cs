using System;
using System.Threading.Tasks;

namespace FastRunner.ExampleApp
{
    class ConsoleWriteTestJob : IFastJob
    {
        public async Task Execute()
        {
            await Console.Out.WriteLineAsync($"Console write test");
        }
    }
}
