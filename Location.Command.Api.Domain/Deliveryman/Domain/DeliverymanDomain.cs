namespace Location.Command.Api.Domain.Deliveryman.Domain;

public sealed record DeliverymanDomain(int Id, string Name, string Document, DateTime BirthDate, string CnhNumber, string CnhType, byte[] ImagePath, bool Active);