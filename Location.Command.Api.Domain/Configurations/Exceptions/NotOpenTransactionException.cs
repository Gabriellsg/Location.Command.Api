namespace Location.Command.Api.Domain.Configurations.Exceptions;

[Serializable]
public class NotOpenTransactionException : Exception
{
    public NotOpenTransactionException()
    {
    }
    public NotOpenTransactionException(string operation) : base($"There is no transaction to {operation}.")
    {
    }
    public NotOpenTransactionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}