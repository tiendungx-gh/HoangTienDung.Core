using HoangTienDung.Core.Entity.Entity;
using HoangTienDung.Core.Entity.Model;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace HoangTienDung.Core.Entity.IRepository
{
    interface IMongoRepository<TEntity, TModel> where TEntity : BaseMongoEntity, new() where TModel : BaseMongoModel
    {
        Task Add(TModel model);
        Task AddRange(IEnumerable<TModel> models);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TModel>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(ObjectId Id);
        Task<IQueryable<TModel>> Query(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TModel>> QueryAll();
        Task Update(TModel model);
        Task UpdateRange(IEnumerable<TModel> models);
    }
}
