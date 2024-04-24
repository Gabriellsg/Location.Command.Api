namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class LocationNotFoundException(int id) : ApplicationException(
    $"Location with identification {id} not found.");