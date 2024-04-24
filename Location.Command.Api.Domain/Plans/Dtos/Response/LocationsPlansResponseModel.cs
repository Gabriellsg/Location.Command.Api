namespace Location.Command.Api.Domain.Plans.Dtos.Response;

public sealed record LocationsPlansResponseModel(int Id, int QuantityDays, decimal ValueDay, decimal? PenaltyPercentage, decimal AdditionalValue);