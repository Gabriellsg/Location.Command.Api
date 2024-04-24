using Location.Command.Api.Domain.Locations.Dtos.Requests;

namespace Location.Command.Api.Domain.Locations.Interfaces;

public interface ILocationServices
{
    Task RegisterLocation(RegisterLocationRequestModel request);
}