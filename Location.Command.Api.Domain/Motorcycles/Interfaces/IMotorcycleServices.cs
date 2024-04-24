using Location.Command.Api.Domain.Motorcycle.Dtos.Request;
using Location.Command.Api.Domain.Motorcycle.Dtos.Response;

namespace Location.Command.Api.Domain.Motorcycle.Interfaces;

public interface IMotorcycleServices
{
    Task RegisterMotorcycle(RegisterMotorcycleRequestModel request);

    Task<IEnumerable<MotorcycleResponseModel>> GetMotorcycle();

    Task<MotorcycleResponseModel?> GetMotorcycleByPlate(string plate);

    Task<MotorcycleResponseModel> UpdateMotorcycle(int id, string plate);

    Task DeleteMotorcycle(string plate);

}