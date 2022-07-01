using Autofac;
using statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile;

namespace statemachineSagasRabbitmqDemo.ReadFile.Modules
{
    public class ReadFileModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReadFileUseCase>().As<IReadFileUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
        }
    }
}
