using Location.Command.Api.Domain.Deliveryman.Domain;
using Location.Command.Api.Domain.Deliveryman.Dtos.Request;

namespace Location.Command.Api.Domain.Deliveryman.Interfaces;

public interface IDeliverymanRepository
{
    Task RegisterDeliveryman(RegisterDeliverymanRequestModel model);

    Task<DeliverymanDomain?> GetDeliverymanByDocument(string document);

    Task<DeliverymanDomain?> GetDeliverymanById(int id);
}