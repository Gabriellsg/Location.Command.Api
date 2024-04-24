using Microsoft.AspNetCore.Http;

namespace Location.Command.Api.Domain.Deliveryman.Dtos.Request;

public sealed record FilePNGModel(IFormFile file);