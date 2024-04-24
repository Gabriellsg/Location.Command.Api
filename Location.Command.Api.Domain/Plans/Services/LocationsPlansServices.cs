using Location.Command.Api.Domain.Extensions;
using Location.Command.Api.Domain.Plans.Dtos.Response;
using Location.Command.Api.Domain.Plans.Interfaces;

namespace Location.Command.Api.Domain.Plans.Services;

public sealed class LocationsPlansServices(ILocationsPlansRepository plansRepository) : ILocationsPlansServices
{
    public async Task<IEnumerable<LocationsPlansResponseModel>> GetLocationPlans()
    {
        var response = await plansRepository.GetLocationPlans();

        var responseList = new LocationsPlansListResponseModel(response.Select(item => item.AsModel())).Result;

        return responseList;
    }
}