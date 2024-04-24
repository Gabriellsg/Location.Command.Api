using Location.Command.Api.Domain.Deliveryman.Dtos.Request;

namespace Location.Command.Api.Domain.Deliveryman.Interfaces;

public interface IDeliverymanServices
{
    Task RegisterDeliveryman(RegisterDeliverymanRequestModel request);
}