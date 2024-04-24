using Location.Command.Api.Domain.Abstractions.Interfaces;
using Location.Command.Api.Domain.Location.Interfaces;
using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Location.Command.Api.Infra.Data.Repository;

public sealed class LocationsRepository : ILocationRepository
{
    private readonly ILogger<LocationsRepository> _logger;
    private readonly IDbConnection _connection;

    public LocationsRepository(ILogger<LocationsRepository> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _connection = unitOfWork.Connection;
    }

    public Task RegisterLocation(RegisterLocationRequestModel model)
    {
        throw new NotImplementedException();
    }
}

