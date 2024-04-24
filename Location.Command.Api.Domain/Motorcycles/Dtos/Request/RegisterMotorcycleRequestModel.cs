namespace Location.Command.Api.Domain.Motorcycle.Dtos.Request;

public sealed record RegisterMotorcycleRequestModel(DateTime Year, string Model, string Plate);