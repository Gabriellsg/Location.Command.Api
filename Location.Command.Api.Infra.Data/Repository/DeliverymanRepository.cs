using Dapper;
using Location.Command.Api.Domain.Abstractions.Interfaces;
using Location.Command.Api.Domain.Deliveryman.Domain;
using Location.Command.Api.Domain.Deliveryman.Dtos.Request;
using Location.Command.Api.Domain.Deliveryman.Interfaces;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Location.Command.Api.Infra.Data.Repository;

    public sealed class DeliverymanRepository : IDeliverymanRepository
    {
        private readonly ILogger<DeliverymanRepository> _logger;
        private readonly IDbConnection _connection;

        public DeliverymanRepository(ILogger<DeliverymanRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _connection = unitOfWork.Connection;
        }

        public async Task RegisterDeliveryman(RegisterDeliverymanRequestModel model)
        {
            try
            {
                var result = await _connection.ExecuteAsync($@"
                    insert into DELIVERYMAN
                    (NAME, DOCUMENT, BIRTH_DATE, CNH_NUMBER, CNH_TYPE, IMAGE_PATH, ACTIVE)
                    values
                    (@Name, @Document, @BirthDate, @CnhNumber, @CnhType, @imagePath, @Active)",
                        new
                        {
                            model.Name,
                            model.Document,
                            model.BirthDate,
                            model.CnhNumber,
                            model.CnhType,
                            ImagePath = string.Empty,
                            model.Active
                        });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar a requisição");
                throw;
            }
        }

        public async Task<DeliverymanDomain?> GetDeliverymanByDocument(string document)
        {
            try
            {
                var result = await _connection.QueryFirstOrDefaultAsync<DeliverymanDomain>($@"
                     SELECT NAME, 
                            DOCUMENT, 
                            BIRTH_DATE, 
                            CNH_NUMBER, 
                            CNH_TYPE, 
                            IMAGE_PATH, 
                            ACTIVE
                     FROM DELIVERYMAN
                     WHERE DOCUMENT = @document",
                        new
                        {
                            document,
                        });

            return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar a requisição");
                throw;
            }
        }

    public async Task<DeliverymanDomain?> GetDeliverymanById(int id)
    {
        try
        {
            var result = await _connection.QueryFirstOrDefaultAsync<DeliverymanDomain>($@"
                     SELECT NAME, 
                            DOCUMENT, 
                            BIRTH_DATE, 
                            CNH_NUMBER, 
                            CNH_TYPE, 
                            IMAGE_PATH, 
                            ACTIVE
                     FROM DELIVERYMAN
                     WHERE ID = @DeliverymanId",
                    new
                    {
                        DeliverymanId = id,
                    });

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar a requisição");
            throw;
        }
    }
}