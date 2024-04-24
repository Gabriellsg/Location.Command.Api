using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Infra.Data.Locations.Domain;

namespace Location.Command.Api.Domain.Location.Interfaces;

public interface ILocationsRepository
{
    Task RegisterLocation(RegisterLocationRequestModel model);

    Task<LocationDomain?> GetLocationById(int Id);

    Task UpdateLocation(LocationDomain location);
}