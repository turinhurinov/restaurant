using Autofac;
using Restaurant.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Ioc.Binders
{
    [ExcludeFromCodeCoverage]
    public static class FrameworkDependencyResolver
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(SmtpService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}