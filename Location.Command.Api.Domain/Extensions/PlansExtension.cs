using Location.Command.Api.Domain.Plans.Domain;
using Location.Command.Api.Domain.Plans.Dtos.Response;

namespace Location.Command.Api.Domain.Extensions;

public static class PlansExtension
{
    public static LocationsPlansResponseModel AsModel(this LocationsPlansDomain self) =>
        new LocationsPlansResponseModel(self.Id, self.QuantityDays, self.DayValue, self.PenaltyPercentage, self.AdditionalValue);
}