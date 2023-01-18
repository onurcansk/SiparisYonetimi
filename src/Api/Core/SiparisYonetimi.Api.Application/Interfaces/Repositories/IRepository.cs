using SiparisYonetimi.Api.Domain.Models;
using System.Linq.Expressions;

namespace SiparisYonetimi.Api.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<int> AddAsync(TEntity entity);
        int Add(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        int Update(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        int Delete(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsyncWithCollection(Guid id, bool noTracking = true, params string[] propertyNames);
        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAllAsync(bool noTracking = true);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
    }
}
