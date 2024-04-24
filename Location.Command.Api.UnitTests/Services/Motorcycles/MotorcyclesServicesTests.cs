using Location.Command.Api.Domain.Motorcycle.Dtos.Request;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Location.Command.Api.Domain.Motorcycle.Services;
using Location.Command.Api.Infra.Data.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System.Data;
using Xunit;

namespace Location.Command.Api.UnitTests.Services.Motorcycles;

public sealed class MotorcyclesServicesTests
{
    private readonly Mock<ILogger<MotorcycleRepository>> _logger;
    private readonly Mock<IDbConnection> _connection;
    private readonly Mock<IMotorcycleRepository> _motorcycleRepository;
    private readonly MotorcycleServices _motorcyclesServices;

    public MotorcyclesServicesTests()
    {
        _logger = new Mock<ILogger<MotorcycleRepository>>();
        _connection = new Mock<IDbConnection>();
        _motorcycleRepository = new Mock<IMotorcycleRepository>(_logger.Object, _connection.Object);

        _motorcyclesServices = new MotorcycleServices(_motorcycleRepository.Object);
    }

    [Fact]
    public async Task Execute_Listar_Motos()
    {
        var request = new RegisterMotorcycleRequestModel(DateTime.Now, "HONDA", "ABC1234");

        _motorcycleRepository
            .Setup(x => x.RegisterMotorcycle(request))
            .Returns(Task.CompletedTask);
        
        await _motorcyclesServices.RegisterMotorcycle(request);
    }

}