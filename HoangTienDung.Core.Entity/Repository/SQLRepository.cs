using AutoMapper;
using HoangTienDung.Core.Entity.Context;
using HoangTienDung.Core.Entity.IRepository;
using HoangTienDung.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HoangTienDung.Core.Entity.Repository
{
    public class SQLRepository<TEntity, TModel> : ISQLRepository<TEntity, TModel> where TEntity : BaseSQLEntity, new() where TModel : BaseSQLModel
    {
        private readonly IMapper _mapper;
        private readonly SQLContext _context;
        private readonly DbSet<TEntity> _dbset;
        public SQLRepository(IMapper mapper, SQLContext context)
        {
            _mapper = mapper;
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public async Task Add(TModel model)
        {
            await _dbset.AddAsync(_mapper.Map<TEntity>(model));
        }

        public async Task AddRange(IEnumerable<TModel> models)
        {
            await _dbset.AddRangeAsync(_mapper.Map<IEnumerable<TEntity>>(models));
        }

        public Task Delete(TModel model)
        {
            _dbset.Remove(_mapper.Map<TEntity>(model));
            return Task.CompletedTask;
        }

        public Task DeleteRange(IEnumerable<TModel> models)
        {
            _dbset.RemoveRange(_mapper.Map<IEnumerable<TEntity>>(models));
            return Task.CompletedTask;
        }

        public async void Dispose()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TModel>>(await _dbset.Where(predicate).ToListAsync());
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TModel>>(await _dbset.ToListAsync());
        }

        public async Task<TModel> GetById(Guid Id)
        {
            return _mapper.Map<TModel>(await _dbset.FindAsync(Id));
        }

        public async Task<IQueryable<TModel>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IQueryable<TModel>>(await _dbset.Where(predicate).ToListAsync());
        }

        public async Task<IQueryable<TModel>> QueryAll()
        {
            return _mapper.Map<IQueryable<TModel>>(await _dbset.ToListAsync());
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(TModel model)
        {
            _context.Update(_mapper.Map<TEntity>(model));
            return Task.CompletedTask;
        }

        public Task UpdateRange(IEnumerable<TModel> models)
        {
            _context.UpdateRange(_mapper.Map<IEnumerable<TEntity>>(models));
            return Task.CompletedTask;
        }
    }
}
