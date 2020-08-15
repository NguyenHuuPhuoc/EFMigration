using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFMigration.Data.Repository
{
    public interface IRepositoryIntegrationLog<T> where T : class
    {
        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        Task<T> GetByIdsAsync(params object[] keyValues);

        Task<T> GetFirstAsync();

        Task<List<T>> ListAllAsync();

        T Add(T entity);

        Task<T> AddAsync(T entity);

        List<T> AddRange(List<T> entityList);

        Task<List<T>> AddRangeAsync(List<T> entityList);

        void Update(T entity);

        void UpdateRange(List<T> entityList);

        void Delete(T entity);

        void DeleteRange(List<T> entityList);

        IQueryable<T> Table { get; }
    }
}