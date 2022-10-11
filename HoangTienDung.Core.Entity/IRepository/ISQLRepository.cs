using HoangTienDung.Core.Entity.Models;
using System.Linq.Expressions;

namespace HoangTienDung.Core.Entity.IRepository
{
    public interface ISQLRepository<TEntity, TModel> : IDisposable where TEntity : BaseSQLEntity, new() where TModel : BaseSQLModel
    {
        Task<TModel> GetById(Guid Id);
        Task<IEnumerable<TModel>> GetAll();
        Task<IEnumerable<TModel>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TModel>> QueryAll();
        Task<IQueryable<TModel>> Query(Expression<Func<TEntity, bool>> predicate);
        Task Add(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        Task AddRange(IEnumerable<TModel> models);
        Task UpdateRange(IEnumerable<TModel> models);
        Task DeleteRange(IEnumerable<TModel> models);
        Task SaveChange();
    }
}
