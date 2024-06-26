﻿using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Location.Command.Api.Domain.Deliveryman.Services;
using Location.Command.Api.Domain.Locations.Interfaces;
using Location.Command.Api.Domain.Locations.Services;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Domain.Motorcycle.Services;
using Location.Command.Api.Domain.Plans.Interfaces;
using Location.Command.Api.Domain.Plans.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Location.Command.Api.Infra.CrossCutting.IoC.Modules;

public static class DomainModule
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMotorcycleServices, MotorcycleServices>();
        services.AddScoped<IDeliverymanServices, DeliverymanServices>();
        services.AddScoped<ILocationsPlansServices, LocationsPlansServices>();
        services.AddScoped<ILocationServices, LocationServices>();
    }
}