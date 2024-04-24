using System.Data;

namespace Location.Command.Api.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    IDbConnection Connection { get; }

    IDbTransaction Transaction { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
}