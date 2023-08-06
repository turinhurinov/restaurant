using Autofac;
using Microsoft.Extensions.Hosting;
using Restaurant.Ioc.Modules;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class RestaurantAutofacContainerConfigurator
    {
        public static void ConfigureContainer(HostBuilderContext context, ContainerBuilder builder)
        {
            builder.RegisterModule(new ApiAutoFacModule(context.Configuration));
        }
    }
}