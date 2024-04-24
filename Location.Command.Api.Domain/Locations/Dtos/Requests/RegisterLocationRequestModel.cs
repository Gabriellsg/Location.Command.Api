namespace Location.Command.Api.Domain.Locations.Dtos.Requests;

public sealed record RegisterLocationRequestModel(
        int DeliverymanId, 
        int LocationPlansId, 
        int MotorcycleId, 
        DateTime LocationStart,
        DateTime LocationEnd,
        DateTime LocationExpectedEnd);