using HoangTienDung.Core.Entity.Entity;
using HoangTienDung.Core.Entity.Model;

namespace HoangTienDung.Core.Entity.IRepository
{
    public interface ICacheRepository<TEntity> where TEntity : CacheModel
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByKeyAsync(string Key);

    }
}
