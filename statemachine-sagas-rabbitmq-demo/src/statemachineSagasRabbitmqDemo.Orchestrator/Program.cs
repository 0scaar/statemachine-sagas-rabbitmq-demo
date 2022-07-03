using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using statemachineSagasRabbitmqDemo.MoveFile.UseCases;
using statemachineSagasRabbitmqDemo.ReadFile.Modules;
using statemachineSagasRabbitmqDemo.MoveFile.Modules;
using statemachineSagasRabbitmqDemo.Orchestrator.Injection;

static IHost AppStartup()
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();

    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.ConfigureQueue();
        })
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterModule<MoveFileModule>();
            container.RegisterModule<ReadFileModule>();
        })
        .UseSerilog()
        .Build();
    return host;
}

using IHost host = AppStartup();

var useCase = host.Services.GetService<IGetTransferFilesUseCase>();

await useCase.Execute();

await host.RunAsync();