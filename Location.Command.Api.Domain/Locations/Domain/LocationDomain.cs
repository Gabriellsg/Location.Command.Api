namespace Location.Command.Api.Infra.Data.Locations.Domain;

public sealed record LocationDomain(
        int Id,
        int DeliverymanId,
        int LocationPlansId,
        int MotorcycleId,
        DateTime LocationStart,
        DateTime? LocationEnd,
        DateTime LocationExpectedEnd,
        decimal? PenaltyValue, 
        decimal? AdditionalValue,
        decimal? TotalValue);