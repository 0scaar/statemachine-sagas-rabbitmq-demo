using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using statemachineSagasRabbitmqDemo.MoveFile.Modules;

namespace statemachineSagasRabbitmqDemo.MoveFile.Injection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder, IServiceCollection services)
        {
            builder.RegisterModule<MoveFileModule>();

            builder.Populate(services);

            return builder;
        }
    }
}
