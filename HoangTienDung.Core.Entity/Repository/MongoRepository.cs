using AutoMapper;
using HoangTienDung.Core.Entity.DataContext;
using HoangTienDung.Core.Entity.Entity;
using HoangTienDung.Core.Entity.IRepository;
using HoangTienDung.Core.Entity.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HoangTienDung.Core.Entity.Repository
{
    public class MongoRepository<TEntity, TModel> : IMongoRepository<TEntity, TModel> where TEntity : BaseMongoEntity, new() where TModel : BaseMongoModel
    {
        private readonly IMapper _mapper;
        private readonly MongoContext _context;
        private readonly IMongoCollection<TEntity> _collection;
        public MongoRepository(IMapper mapper, MongoContext context)
        {
            _mapper = mapper;
            _context = context;
            _collection = _context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Add(TModel model)
        {
            await _collection.InsertOneAsync(_mapper.Map<TEntity>(model));
        }

        public async Task AddRange(IEnumerable<TModel> models)
        {
            await _collection.InsertManyAsync(_mapper.Map<IEnumerable<TEntity>>(models));
        }

        public Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _collection.FindOneAndDelete(predicate);
            return Task.CompletedTask;
        }

        public Task DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            _collection.DeleteManyAsync(predicate);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TModel>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TModel>>(await _collection.FindAsync(predicate));
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TModel>>(await _collection.FindAsync(Builders<TEntity>.Filter.Empty));
        }

        public async Task<TModel> GetById(ObjectId Id)
        {
            return _mapper.Map<TModel>(await _collection.FindAsync(Builders<TEntity>.Filter.Eq(doc => doc.Id, Id)));
        }

        public async Task<IQueryable<TModel>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IQueryable<TModel>>(await _collection.FindAsync(predicate));
        }

        public async Task<IQueryable<TModel>> QueryAll()
        {
            return _mapper.Map<IQueryable<TModel>>(await _collection.FindAsync(Builders<TEntity>.Filter.Empty));
        }

        public Task Update(TModel model)
        {
            _collection.FindOneAndReplaceAsync(Builders<TEntity>.Filter.Eq(doc => doc.Id, model.Id), _mapper.Map<TEntity>(model));
            return Task.CompletedTask;
        }

        public Task UpdateRange(IEnumerable<TModel> models)
        {
            models.ToList().ForEach(model =>
                {
                    _collection.FindOneAndReplaceAsync(Builders<TEntity>.Filter.Eq(doc => doc.Id, model.Id), _mapper.Map<TEntity>(model));
                });
            return Task.CompletedTask;
        }
    }
}
