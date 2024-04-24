using Location.Command.Api.Domain.Motorcycle.Dtos.Request;
using Location.Command.Api.Domain.Motorcycle.Dtos.Response;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Location.Command.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("[controller]")]

public sealed class MotorcycleController(IMotorcycleServices _services, ILogger<MotorcycleController> _logger) : ControllerBase
{
    [HttpPost("RegisterMotorcycle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(RegisterMotorcycleRequestModel request)
    {
		try
		{
            await _services.RegisterMotorcycle(request);

            return Ok();
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, exception.Message);
			return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
		}
    }

    [HttpGet("GetMotorcycle")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<MotorcycleResponseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _services.GetMotorcycle();

            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }

    [HttpGet("GetMotorcycle/plate")]
    [ProducesResponseType(typeof(ApiResponse<MotorcycleResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(string plate)
    {
        try
        {
            return await Task.FromResult<IActionResult>(Ok(new ApiResponse<MotorcycleResponseModel>(_services.GetMotorcycleByPlate(plate).Result)));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }

    [HttpPut("UpdateMotorcycle")]
    [ProducesResponseType(typeof(ApiResponse<MotorcycleResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(int id, string plate)
    {
        try
        {
            return await Task.FromResult<IActionResult>(Ok(new ApiResponse<MotorcycleResponseModel>(_services.UpdateMotorcycle(id, plate).Result)));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }

    [HttpDelete("DeleteMotorcycle")]
    [ProducesResponseType(typeof(ApiResponse<MotorcycleResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string plate)
    {
        try
        {
            await _services.DeleteMotorcycle(plate);
            return Ok();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return await Task.FromResult<IActionResult>(BadRequest(new ApiResponse<object>(null, exception.Message)));
        }
    }
}