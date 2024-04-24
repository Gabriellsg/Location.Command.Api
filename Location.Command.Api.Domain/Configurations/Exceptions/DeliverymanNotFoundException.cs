namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class DeliverymanNotFoundException(int id) : ApplicationException(
        $"Deliveryman with identification {id} not found.");