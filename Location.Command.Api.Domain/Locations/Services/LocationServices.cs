using Location.Command.Api.Domain.Configurations.Exceptions;
using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Location.Command.Api.Domain.Location.Interfaces;
using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Domain.Locations.Interfaces;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Domain.Plans.Interfaces;

namespace Location.Command.Api.Domain.Locations.Services;

public sealed class LocationServices(
    ILocationRepository locationRepository, 
    IDeliverymanRepository deliverymanRepository,
    IMotorcycleRepository motorcycleRepository,
    ILocationsPlansRepository locationsPlansRepository) : ILocationServices
{
    public async Task RegisterLocation(RegisterLocationRequestModel request)
    {
        _= await deliverymanRepository.GetDeliverymanById(request.DeliverymanId)
            ?? throw new DeliverymanNotFoundException(request.DeliverymanId);

        _ = await motorcycleRepository.GetMotorcycleById(request.DeliverymanId)
            ?? throw new DeliverymanNotFoundException(request.DeliverymanId);

        _ = await locationsPlansRepository.GetLocationPlansById(request.DeliverymanId)
            ?? throw new LocationPlansNotFoundException(request.DeliverymanId);

        await locationRepository.RegisterLocation(request);
    }


}
