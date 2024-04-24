using Dapper;
using Location.Command.Api.Domain.Location.Interfaces;
using Location.Command.Api.Domain.Locations.Dtos.Requests;
using Location.Command.Api.Infra.Data.Locations.Domain;
using Microsoft.Extensions.Logging;
using Npgsql;
using RabbitMQ.Client;
using System.Data;
using System.Text;
using System.Text.Json;

namespace Location.Command.Api.Infra.Data.Repository;

public sealed class LocationsRepository : ILocationsRepository
{
    private readonly ILogger<LocationsRepository> _logger;
    private readonly IDbConnection _connection;

    public LocationsRepository(ILogger<LocationsRepository> logger, IDbConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public async Task RegisterLocation(RegisterLocationRequestModel request)
    {
        try
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "location-receiver-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(request);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "location-receiver-queue",
                                 basicProperties: null,
                                 body: body);

            _logger.LogInformation($"[x] Sent {message}");

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task<LocationDomain?> GetLocationById(int Id)
    {
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<LocationDomain>($@"
                    SELECT 
                        ID as {nameof(LocationDomain.Id)},  
                        DELIVERYMAN_ID as {nameof(LocationDomain.DeliverymanId)}, 
                        LOCATION_PLANS_ID as {nameof(LocationDomain.LocationPlansId)}, 
                        MOTORCYCLE_ID as {nameof(LocationDomain.MotorcycleId)},
                        LOCATION_START as {nameof(LocationDomain.LocationStart)},
                        LOCATION_END as {nameof(LocationDomain.LocationEnd)}, 
                        LOCATION_EXPECTED_END as {nameof(LocationDomain.LocationExpectedEnd)},
                        PENALTY_VALUE as {nameof(LocationDomain.PenaltyValue)},
                        ADDITIONAL_VALUE as {nameof(LocationDomain.AdditionalValue)},
                        TOTAL_VALUE as {nameof(LocationDomain.TotalValue)}
                    FROM LOCATIONS
                    WHERE ID = @LocationId",
                    new
                    {
                        LocationId = Id
                    });

            return result;
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task UpdateLocation(LocationDomain location)
    {
        try
        {
            await _connection.ExecuteAsync($@"
                    UPDATE LOCATIONS SET 
                        LOCATION_END = @FinishLocation,
                        PENALTY_VALUE = @PenaltyValue,
                        ADDITIONAL_VALUE = @AdditionalValue,
                        TOTAL_VALUE = @TotalValue
                    WHERE ID = @LocationId",
                    new
                    {
                        FinishLocation = location.LocationEnd,
                        location.PenaltyValue,
                        location.AdditionalValue,
                        TotalValue = location.TotalValue,
                        LocationId = location.Id
                    });
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }
}