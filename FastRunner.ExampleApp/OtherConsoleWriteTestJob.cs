using System;
using System.Threading.Tasks;

namespace FastRunner.ExampleApp
{
    class OtherConsoleWriteTestJob : IFastJob
    {
        public async Task Execute()
        {
            await Console.Out.WriteLineAsync($"Other console write test");
        }
    }
}
