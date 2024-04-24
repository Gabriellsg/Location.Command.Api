using Location.Command.Api.Domain.Enums;

namespace Location.Command.Api.Domain.Deliveryman.Dtos.Request;

public sealed record RegisterDeliverymanRequestModel(string Name, string Document, DateTime BirthDate, string CnhNumber, TypeCNH CnhType, bool Active = true);