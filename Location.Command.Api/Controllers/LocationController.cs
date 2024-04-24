using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Domain.Locations.Dtos.Response;
using Location.Command.Api.Domain.Locations.Interfaces;
using Location.Command.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Location.Command.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController(ILocationServices _services, ILogger<LocationController> _logger) : ControllerBase
{

    [HttpPost("RegisterLocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(RegisterLocationRequestModel request)
    {
        try
        {
            await _services.RegisterLocation(request);

            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }


    [HttpPost("FinishLocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PostFinish(FinishLocationRequestModel request)
    {
        try
        {
            await _services.FinishLocation(request);

            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }

    [HttpGet("GetLocation/id")]
    [ProducesResponseType(typeof(ApiResponse<LocationResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return await Task.FromResult<IActionResult>(Ok(new ApiResponse<LocationResponseModel>(_services.GetLocationById(id).Result)));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }
}