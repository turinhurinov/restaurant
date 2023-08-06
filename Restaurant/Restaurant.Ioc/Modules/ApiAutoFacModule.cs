using Autofac;
using Microsoft.Extensions.Configuration;
using Restaurant.Ioc.Binders;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Ioc.Modules
{
    [ExcludeFromCodeCoverage]
    public class ApiAutoFacModule : Module
    {
        readonly IConfiguration configuration;

        public ApiAutoFacModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            DataDependencyResolver.RegisterServices(builder);
            BusinessDependencyResolver.RegisterServices(builder);
            FrameworkDependencyResolver.RegisterServices(builder);
        }
    }
}