using Location.Command.Api.Domain.Configurations.Exceptions;
using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Location.Command.Api.Domain.Extensions;
using Location.Command.Api.Domain.Location.Interfaces;
using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Domain.Locations.Dtos.Response;
using Location.Command.Api.Domain.Locations.Interfaces;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Domain.Plans.Domain;
using Location.Command.Api.Domain.Plans.Interfaces;
using Location.Command.Api.Infra.Data.Locations.Domain;

namespace Location.Command.Api.Domain.Locations.Services;

public sealed class LocationServices(
    ILocationsRepository locationRepository,
    IDeliverymanRepository deliverymanRepository,
    IMotorcycleRepository motorcycleRepository,
    ILocationsPlansRepository locationsPlansRepository) : ILocationServices
{
    public async Task RegisterLocation(RegisterLocationRequestModel request)
    {
        var deliveryman = await deliverymanRepository.GetDeliverymanById(request.DeliverymanId)
            ?? throw new DeliverymanNotFoundException(request.DeliverymanId);

        _ = await motorcycleRepository.GetMotorcycleById(request.MotorcycleId)
            ?? throw new MotorcycleNotFoundException(request.MotorcycleId);

        _ = await locationsPlansRepository.GetLocationPlansById(request.LocationPlansId)
            ?? throw new LocationPlansNotFoundException(request.LocationPlansId);

        if (deliveryman.CnhType != Enums.TypeCNH.A)
         throw new LicenseTypeNotAllowedException(deliveryman.CnhType);

        await locationRepository.RegisterLocation(request);
    }

    public async Task FinishLocation(FinishLocationRequestModel request)
    {
        var location = await locationRepository.GetLocationById(request.Id)
            ?? throw new LocationNotFoundException(request.Id);

        if (location.TotalValue is not null)
            throw new LocationFinishedException(request.Id);

        var usedPlan = await locationsPlansRepository.GetLocationPlansById(location.LocationPlansId);

        var locationToUpdate = CalculateLocation(location, usedPlan!, request.finishDate);

        await locationRepository.UpdateLocation(locationToUpdate);
    }

    private LocationDomain CalculateLocation(LocationDomain location, LocationsPlansDomain usedPlan, DateTime finishLocation)
    {
        decimal totalValue = usedPlan.DayValue * usedPlan.QuantityDays;
        decimal additionalValue = 0;
        decimal totalPenaltyValue = 0;

        if (finishLocation < location.LocationExpectedEnd)
        {
            var differenceDays = location.LocationExpectedEnd.Date.Subtract(finishLocation.Date);
            var dayValueWithPenalty = usedPlan.DayValue + (usedPlan.DayValue * (usedPlan.PenaltyPercentage / 100));
            totalPenaltyValue = dayValueWithPenalty * (int)differenceDays.TotalDays;

            totalValue += totalPenaltyValue;
        }

        if (finishLocation > location.LocationExpectedEnd)
        {
            var differenceDays = finishLocation.Date.Subtract(location.LocationExpectedEnd.Date);
            var dayValueWithPenalty = usedPlan.DayValue + (usedPlan.DayValue * (usedPlan.PenaltyPercentage / 100));
            additionalValue = 50 * (int)differenceDays.TotalDays;

            totalPenaltyValue = dayValueWithPenalty * (int)differenceDays.TotalDays + additionalValue;

            totalValue += totalPenaltyValue;
        }

        return new LocationDomain(
                location.Id,
                location.DeliverymanId,
                location.LocationPlansId,
                location.MotorcycleId,
                location.LocationStart,
                finishLocation,
                location.LocationExpectedEnd,
                totalPenaltyValue,
                additionalValue,
                totalValue);
    }

    public async Task<LocationResponseModel> GetLocationById(int id)
    {
        var response = await locationRepository.GetLocationById(id)
           ?? throw new LocationNotFoundException(id);

        return response.AsModel();
    }
}