using EFMigration.Data.Data;
using EFMigration.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFMigration.Data.UnitOfWork
{
    public class UnitOfWorkIntegrationLog : IUnitOfWorkIntegrationLog
    {
        private Dictionary<Type, object> _repositories;
        private IntegrationLogContext Context { get; }

        public UnitOfWorkIntegrationLog(IntegrationLogContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepositoryIntegrationLog<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new EfRepositoryIntegrationLog<TEntity>(Context);
            return (IRepositoryIntegrationLog<TEntity>)_repositories[type];
        }

        public IntegrationLogContext GetIntegrationLogContext()
        {
            return Context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
