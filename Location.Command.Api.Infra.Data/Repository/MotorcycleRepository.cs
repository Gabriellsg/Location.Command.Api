using Dapper;
using Location.Command.Api.Domain.Motorcycle.Domain;
using Location.Command.Api.Domain.Motorcycle.Dtos.Request;
using Location.Command.Api.Domain.Motorcycle.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace Location.Command.Api.Infra.Data.Repository;

public sealed class MotorcycleRepository : IMotorcycleRepository
{
    private readonly ILogger<MotorcycleRepository> _logger;
    private readonly IDbConnection _connection;

    public MotorcycleRepository(ILogger<MotorcycleRepository> logger, IDbConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public async Task RegisterMotorcycle(RegisterMotorcycleRequestModel model)
    {
        try
        {
            var result = await _connection.ExecuteAsync($@"
                    INSERT INTO MOTORCYCLE (YEAR, MODEL, PLATE)
                    VALUES(@year, @model, @plate)",
                    new
                    {
                        year = model.Year,
                        model = model.Model,
                        plate = model.Plate
                    });
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task<IEnumerable<MotorcycleDomain>> GetMotorcycle()
    {
        try
        {         
            var result = await _connection.QueryAsync<MotorcycleDomain>($@"
                     SELECT 
                        ID as {nameof(MotorcycleDomain.Id)}, 
                        YEAR as {nameof(MotorcycleDomain.Year)}, 
                        MODEL as {nameof(MotorcycleDomain.Model)}, 
                        PLATE as {nameof(MotorcycleDomain.Plate)} 
                     FROM MOTORCYCLE", 
                     null, 
                     commandType: CommandType.Text);

            return result;
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task<MotorcycleDomain?> GetMotorcycleByPlate(string plate)
    {
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<MotorcycleDomain>($@"
                    SELECT  
                        ID as {nameof(MotorcycleDomain.Id)}, 
                        YEAR as {nameof(MotorcycleDomain.Year)}, 
                        MODEL as {nameof(MotorcycleDomain.Model)}, 
                        PLATE as {nameof(MotorcycleDomain.Plate)}  
                    FROM MOTORCYCLE
                    WHERE PLATE = @plate",
                    new
                    {
                        plate
                    });

            return result;
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task<MotorcycleDomain?> GetMotorcycleById(int Id)
    {
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<MotorcycleDomain>($@"
                    SELECT  
                        ID as {nameof(MotorcycleDomain.Id)}, 
                        YEAR as {nameof(MotorcycleDomain.Year)}, 
                        MODEL as {nameof(MotorcycleDomain.Model)}, 
                        PLATE as {nameof(MotorcycleDomain.Plate)} 
                    FROM MOTORCYCLE
                    WHERE ID = @Id",
                    new
                    {
                        Id
                    });

            return result;
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task UpdateMotorcycle(int motorcycleId, string plate)
    {
        try
        {
            await _connection.ExecuteAsync($@"
                    UPDATE MOTORCYCLE SET PLATE = @plate
                    WHERE ID = @motorcycleId",
                    new
                    {
                        motorcycleId,
                        plate
                    });
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }

    public async Task RemoveMotorcycle(string plate)
    {
        try
        {
            await _connection.ExecuteAsync($@"
                    DELETE FROM MOTORCYCLE WHERE PLATE = @plate",
                    new
                    {
                        plate
                    });
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }
}

