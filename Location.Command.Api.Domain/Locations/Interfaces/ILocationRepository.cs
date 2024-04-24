using Location.Command.Api.Domain.Locations.Dtos.Requests;

namespace Location.Command.Api.Domain.Location.Interfaces;

public interface ILocationRepository
{
    Task RegisterLocation(RegisterLocationRequestModel model);
}