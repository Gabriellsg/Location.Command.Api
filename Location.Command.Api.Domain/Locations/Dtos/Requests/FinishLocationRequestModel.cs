namespace Location.Command.Api.Domain.Locations.Dtos.Requests;

public sealed record class FinishLocationRequestModel(int Id, DateTime finishDate);