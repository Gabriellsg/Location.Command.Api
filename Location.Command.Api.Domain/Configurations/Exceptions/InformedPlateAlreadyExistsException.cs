namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class InformedPlateAlreadyExistsException(string plate) : ApplicationException(
        $"Informed plate {plate} already exists.");