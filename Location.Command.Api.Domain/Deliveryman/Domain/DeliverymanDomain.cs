using Location.Command.Api.Domain.Enums;

namespace Location.Command.Api.Domain.Deliveryman.Domain;

public sealed record DeliverymanDomain(
    int Id, 
    string Name, 
    string Document, 
    DateTime BirthDate, 
    string CnhNumber,
    TypeCNH CnhType, 
    string ImagePath, 
    bool Active);