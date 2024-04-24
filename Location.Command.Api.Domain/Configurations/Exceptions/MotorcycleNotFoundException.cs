namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class MotorcycleNotFoundException(int id) : ApplicationException(
    $"Motorcycle with identification {id} not found.");
