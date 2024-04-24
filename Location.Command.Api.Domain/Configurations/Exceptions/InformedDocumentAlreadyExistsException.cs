namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class InformedDocumentAlreadyExistsException(string document) : ApplicationException(
        $"Informed document {document} already exists.");
