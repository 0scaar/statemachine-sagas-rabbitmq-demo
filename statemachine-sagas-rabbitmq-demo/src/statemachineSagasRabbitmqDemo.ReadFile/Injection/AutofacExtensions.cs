using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using statemachineSagasRabbitmqDemo.Infrastructure.Modules;
using statemachineSagasRabbitmqDemo.ReadFile.Modules;

namespace statemachineSagasRabbitmqDemo.ReadFile.Injection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder, IServiceCollection services)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ReadFileModule>();

            builder.Populate(services);

            return builder;
        }
    }
}
