using Location.Command.Api.Domain.Motorcycle.Domain;
using Location.Command.Api.Domain.Motorcycle.Dtos.Request;

namespace Location.Command.Api.Domain.Motorcycle.Interfaces;

public interface IMotorcycleRepository
{
    Task RegisterMotorcycle(RegisterMotorcycleRequestModel model);

    Task<IEnumerable<MotorcycleDomain>> GetMotorcycle();

    Task<MotorcycleDomain?> GetMotorcycleByPlate(string plate);

    Task<MotorcycleDomain?> GetMotorcycleById(int Id);

    Task UpdateMotorcycle(int id, string plate);

    Task RemoveMotorcycle(string plate);
}