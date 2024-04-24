using Location.Command.Api.Domain.Plans.Dtos.Response;

namespace Location.Command.Api.Domain.Plans.Interfaces;

public interface ILocationsPlansServices
{
    Task<IEnumerable<LocationsPlansResponseModel>> GetLocationPlans();
}