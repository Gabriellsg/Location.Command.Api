using Location.Command.Api.Domain.Motorcycle.Domain;
using Location.Command.Api.Domain.Motorcycle.Dtos.Response;

namespace Location.Command.Api.Domain.Extensions;

public static class MotorcycleExtension
{
    public static MotorcycleResponseModel AsModel(this MotorcycleDomain self) =>
        new MotorcycleResponseModel(self.Id, self.Plate, self.Year, self.Model);
}

