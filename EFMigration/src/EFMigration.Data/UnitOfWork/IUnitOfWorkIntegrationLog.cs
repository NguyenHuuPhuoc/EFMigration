using EFMigration.Data.Data;
using EFMigration.Data.Repository;
using System;
using System.Threading.Tasks;

namespace EFMigration.Data.UnitOfWork
{
    public interface IUnitOfWorkIntegrationLog : IDisposable
    {
        IRepositoryIntegrationLog<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IntegrationLogContext GetIntegrationLogContext();
    }
}