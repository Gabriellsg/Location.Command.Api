namespace Location.Command.Api.Domain.Locations.Dtos.Response;

public sealed record LocationResponseModel(
        int Id,
        int DeliverymanId,
        int locationPlansId,
        int MotorcycleId,
        DateTime LocationStart,
        DateTime? LocationEnd,
        DateTime LocationExpectedEnd,
        decimal? PenaltyValue,
        decimal? AdditionalValue,
        decimal? TotalValue);