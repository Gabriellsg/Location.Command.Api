using Location.Command.Api.Domain.Motorcycle.Services;
using Location.Command.Api.Infra.Data.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Npgsql;
using System.Data;
using Xunit;

namespace Location.Command.Api.UnitTests.Services.Motorcycles;

public sealed class MotorcyclesServicesTests
{
    private readonly Mock<ILogger<MotorcycleRepository>> _logger;
    private readonly IDbConnection _connection;
    private const string ConnectionString = "User ID=postgres;Password=postgres;Host=database-2.cr2agywysgmr.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;";
    private readonly MotorcycleServices _motorcyclesServices;
    private readonly MotorcycleRepository _motorcycleRepository;

    public MotorcyclesServicesTests()
    {
        _logger = new Mock<ILogger<MotorcycleRepository>>();
        _connection = new NpgsqlConnection(ConnectionString); 
        _motorcycleRepository = new MotorcycleRepository(_logger.Object, _connection);
        _motorcyclesServices = new MotorcycleServices(_motorcycleRepository);
    }

    [Fact]
    public async void Execute_GetMotorcycleList_Success()
    {
        //act
        _connection.Open();

        var result = await _motorcyclesServices.GetMotorcycle();

        _connection.Close();

        //assert
        Assert.NotNull(result);
    }
}