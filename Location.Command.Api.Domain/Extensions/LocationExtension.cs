using Location.Command.Api.Domain.Locations.Dtos.Response;
using Location.Command.Api.Infra.Data.Locations.Domain;

namespace Location.Command.Api.Domain.Extensions;

public static class LocationExtension
{
    public static LocationResponseModel AsModel(this LocationDomain self) =>
    new LocationResponseModel(
        self.Id, 
        self.DeliverymanId, 
        self.LocationPlansId, 
        self.MotorcycleId, 
        self.LocationStart, 
        self.LocationEnd, 
        self.LocationExpectedEnd, 
        self.PenaltyValue, 
        self.AdditionalValue,
        self.TotalValue);
}