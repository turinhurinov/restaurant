using Autofac;
using Restaurant.Framework.Abtract;
using Restaurant.Framework.Factories;
using Restaurant.Framework.Services;
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
            builder.RegisterAssemblyTypes(typeof(MailMessageFactory).Assembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<Settings>().As<ISettings>();
        }
    }
}