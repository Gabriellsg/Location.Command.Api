using Location.Command.Api.Domain.Configurations.Exceptions;
using Location.Command.Api.Domain.Deliveryman.Dtos.Request;
using Location.Command.Api.Domain.Deliveryman.Interfaces;

namespace Location.Command.Api.Domain.Deliveryman.Services;

public sealed class DeliverymanServices(IDeliverymanRepository deliverymanRepository) : IDeliverymanServices
{
    public async Task RegisterDeliveryman(RegisterDeliverymanRequestModel request)
    {
        var recordFound = await deliverymanRepository.GetDeliverymanByDocument(request.Document);

        if (recordFound is not null)
            throw new InformedDocumentAlreadyExistsException(request.Document);

        await deliverymanRepository.RegisterDeliveryman(request);
    }
}