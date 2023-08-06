using Autofac;
using Restaurant.Business.Services;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Ioc.Binders
{
    [ExcludeFromCodeCoverage]
    public static class BusinessDependencyResolver
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ReservationService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ReservationFactory).Assembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}