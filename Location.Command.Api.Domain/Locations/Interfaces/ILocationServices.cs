using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Domain.Locations.Dtos.Response;

namespace Location.Command.Api.Domain.Locations.Interfaces;

public interface ILocationServices
{
    Task RegisterLocation(RegisterLocationRequestModel request);

    Task FinishLocation(FinishLocationRequestModel request);

    Task<LocationResponseModel> GetLocationById(int id);
}