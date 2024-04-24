using Location.Command.Api.Domain.Abstractions.Interfaces;
using Location.Command.Api.Infra.Data.Contexts;
using Location.Command.Api.Infra.Data.Contexts.DataConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace Location.Command.Api.Infra.CrossCutting.IoC.Modules;

public static class DataModule
{
    private const string ConnectionStringName = "connection_BD";

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseConfig(configuration);
        services.AddTransient<IDbConnection>(provider =>
        {
            var connectionString = provider.GetRequiredService<DatabaseConfig>().ConnectionString;
            return new NpgsqlConnection(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration) => services
        .AddSingleton(_ =>
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            var sqlConnection = new NpgsqlConnectionStringBuilder(connectionString)
            {
                CommandTimeout = 12000,
                MinPoolSize = 5,
                MaxPoolSize = 50,
                Pooling = true,
                ConnectionIdleLifetime = 12000,
            }
            ;

            return new DatabaseConfig()
            {
                ConnectionString = sqlConnection.ConnectionString
            };
        });
}