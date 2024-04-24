using Location.Command.Api.Domain.Deliveryman.Dtos.Request;
using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Location.Command.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Location.Command.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public sealed class DeliverymanController(IDeliverymanServices _services, ILogger<MotorcycleController> _logger) : ControllerBase
{
    [HttpPost("RegisterDeliveryman")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(RegisterDeliverymanRequestModel request)
    {
        try
        {
            await _services.RegisterDeliveryman(request);

            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }
}