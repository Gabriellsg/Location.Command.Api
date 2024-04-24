using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Location.Command.Api.Domain.Location.Interfaces;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Domain.Plans.Interfaces;
using Location.Command.Api.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Location.Command.Api.Infra.CrossCutting.IoC.Modules;

public static class InfraStructureModule
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
        services.AddScoped<ILocationsPlansRepository, LocationPlansRepository>();
        services.AddScoped<ILocationsRepository, LocationsRepository>();
    }
}