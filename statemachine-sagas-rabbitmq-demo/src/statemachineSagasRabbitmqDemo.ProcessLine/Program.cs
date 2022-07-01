using Microsoft.Extensions.Hosting;
using statemachineSagasRabbitmqDemo.ProcessLine.Injection;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(s => s.ConfigureQueue())
    .Build();

await host.RunAsync();