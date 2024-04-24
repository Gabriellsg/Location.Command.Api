using Location.Command.Api.Domain.Plans.Dtos.Response;
using Location.Command.Api.Domain.Plans.Interfaces;
using Location.Command.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Location.Command.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]
public class PlansController(ILocationsPlansServices _services, ILogger<PlansController> _logger) : ControllerBase
{
    [HttpGet("GetPlans")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<LocationsPlansResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _services.GetLocationPlans();

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }
}