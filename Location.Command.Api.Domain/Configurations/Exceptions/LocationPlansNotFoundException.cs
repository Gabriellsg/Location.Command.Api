namespace Location.Command.Api.Domain.Configurations.Exceptions;

    public sealed class LocationPlansNotFoundException(int id) : ApplicationException(
        $"Location plans with identification {id} not found.");