using Autofac;
using Restaurant.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Ioc.Binders
{
    [ExcludeFromCodeCoverage]
    public static class DataDependencyResolver
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ReservationRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}