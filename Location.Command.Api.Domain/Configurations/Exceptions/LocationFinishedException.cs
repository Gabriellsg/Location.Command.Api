namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class LocationFinishedException(int id) : ApplicationException(
    $"Location with identification {id} finished.");