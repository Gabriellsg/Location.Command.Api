namespace Location.Command.Api.Domain.Plans.Domain;

public sealed record LocationsPlansDomain(int Id, int QuantityDays, decimal DayValue, decimal PenaltyPercentage, decimal AdditionalValue);