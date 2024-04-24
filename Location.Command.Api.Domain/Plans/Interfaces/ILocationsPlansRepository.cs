using Location.Command.Api.Domain.Motorcycle.Domain;
using Location.Command.Api.Domain.Plans.Domain;

namespace Location.Command.Api.Domain.Plans.Interfaces;

public interface ILocationsPlansRepository
{
    Task<IEnumerable<LocationsPlansDomain>> GetLocationPlans();

    Task<LocationsPlansDomain?> GetLocationPlansById(int Id);
}