using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFMigration.Data.Repository
{
    /// <summary>
    /// This class is used for custom Repository, in case the Entity does not inherit from BaseEntity, has string as primary key
    /// </summary>
    public class EfRepositoryIntegrationLog<T> : IRepositoryIntegrationLog<T> where T : class
    {
        private readonly DbContext _dbContext;

        private DbSet<T> _entities;

        public EfRepositoryIntegrationLog(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return _entities.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<T> GetByIdsAsync(params object[] keyValues)
        {
            return await _entities.FindAsync(keyValues);
        }

        public async Task<T> GetFirstAsync()
        {
            return await _entities.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public T Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }

        public List<T> AddRange(List<T> entityList)
        {
            _entities.AddRange(entityList);
            return entityList;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entityList)
        {
            await _entities.AddRangeAsync(entityList);
            return entityList;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Update(entity);
        }

        public void UpdateRange(List<T> entityList)
        {
            foreach (var entity in entityList)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.UpdateRange(entityList);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(List<T> entityList)
        {
            _entities.RemoveRange(entityList);
        }

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;
            }
        }
    }
}
