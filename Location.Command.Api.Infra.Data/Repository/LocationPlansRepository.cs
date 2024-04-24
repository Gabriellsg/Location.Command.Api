using Dapper;
using Location.Command.Api.Domain.Plans.Domain;
using Location.Command.Api.Domain.Plans.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace Location.Command.Api.Infra.Data.Repository;

public sealed class LocationPlansRepository : ILocationsPlansRepository
{
    private readonly ILogger<LocationPlansRepository> _logger;
    private readonly IDbConnection _connection;

    public LocationPlansRepository(ILogger<LocationPlansRepository> logger, IDbConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public async Task<IEnumerable<LocationsPlansDomain>> GetLocationPlans()
    {
        try
        {
            var result = await _connection.QueryAsync<LocationsPlansDomain>($@"
                  SELECT 
                    ID, 
                    QUANTITY_DAYS AS {nameof(LocationsPlansDomain.QuantityDays)}, 
                    DAY_VALUE AS {nameof(LocationsPlansDomain.DayValue)}, 
                    PENALTY_PERCENTAGE AS {nameof(LocationsPlansDomain.PenaltyPercentage)}, 
                    ADDITIONAL_VALUE AS {nameof(LocationsPlansDomain.AdditionalValue)}
                  FROM LOCATION_PLANS",
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

    public async Task<LocationsPlansDomain?> GetLocationPlansById(int id)
    {
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<LocationsPlansDomain>($@"
                  SELECT 
                    ID, 
                    QUANTITY_DAYS AS {nameof(LocationsPlansDomain.QuantityDays)}, 
                    DAY_VALUE AS {nameof(LocationsPlansDomain.DayValue)}, 
                    PENALTY_PERCENTAGE AS {nameof(LocationsPlansDomain.PenaltyPercentage)}, 
                    ADDITIONAL_VALUE AS {nameof(LocationsPlansDomain.AdditionalValue)}
                  FROM LOCATION_PLANS
                  WHERE ID = @LocationPlansId",
                  new
                  {
                      LocationPlansId = id,
                  });

            return result;
        }
        catch (NpgsqlException ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }
}