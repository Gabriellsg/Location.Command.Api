using Location.Command.Api.Domain.Configurations.Exceptions;
using Location.Command.Api.Domain.Extensions;
using Location.Command.Api.Domain.Motorcycle.Dtos.Request;
using Location.Command.Api.Domain.Motorcycle.Dtos.Response;
using Location.Command.Api.Domain.Motorcycle.Interfaces;

namespace Location.Command.Api.Domain.Motorcycle.Services;

public sealed class MotorcycleServices(IMotorcycleRepository motorcycleRepository) : IMotorcycleServices
{
    public async Task RegisterMotorcycle(RegisterMotorcycleRequestModel request)
    {
        var recordFound = await motorcycleRepository.GetMotorcycleByPlate(request.Plate);

        if (recordFound is not null)
            throw new InformedPlateAlreadyExistsException(request.Plate);

        await motorcycleRepository.RegisterMotorcycle(request);
    }

    public async Task<IEnumerable<MotorcycleResponseModel>> GetMotorcycle()
    {
        var response = await motorcycleRepository.GetMotorcycle();

        var responseList = new MotorcycleListResponseModel(response.Select(item => item.AsModel())).Result;

        return responseList;
    }

    public async Task<MotorcycleResponseModel?> GetMotorcycleByPlate(string plate)
    {
        var response = await motorcycleRepository.GetMotorcycleByPlate(plate)
            ?? throw new Exception("No records found");

        return response.AsModel();
    }

    public async Task<MotorcycleResponseModel> UpdateMotorcycle(int Id, string plate)
    {
        _ = await motorcycleRepository.GetMotorcycleById(Id)
            ?? throw new Exception("No records found");

        await motorcycleRepository.UpdateMotorcycle(Id, plate);

        var response = await motorcycleRepository.GetMotorcycleById(Id);

        return response!.AsModel();
    }

    public async Task DeleteMotorcycle(string plate)
    {
        await motorcycleRepository.RemoveMotorcycle(plate);
    }
}

