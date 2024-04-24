namespace Location.Command.Api.Domain.Motorcycle.Dtos.Response;

public sealed record MotorcycleListResponseModel(IEnumerable<MotorcycleResponseModel> Result);