using Autofac;
using statemachineSagasRabbitmqDemo.MoveFile.UseCases;

namespace statemachineSagasRabbitmqDemo.MoveFile.Modules
{
    public class MoveFileModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetTransferFilesUseCase>().As<IGetTransferFilesUseCase>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
        }
    }
}
