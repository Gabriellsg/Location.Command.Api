using Location.Command.Api.Domain.Enums;
using Location.Command.Api.Domain.Extensions;

namespace Location.Command.Api.Domain.Configurations.Exceptions;

public sealed class LicenseTypeNotAllowedException(TypeCNH cnhType) : ApplicationException(
    $"License type {cnhType.GetDescription()} not allowed.");