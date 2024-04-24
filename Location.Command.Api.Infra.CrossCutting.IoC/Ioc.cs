using Location.Command.Api.Infra.CrossCutting.IoC.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Location.Command.Api.Infra.CrossCutting.IoC;

public static class Ioc
{
    public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
    {
        DataModule.Register(services, configuration);
        DomainModule.Register(services, configuration);
        InfraStructureModule.Register(services, configuration);
        return services;
    }
}