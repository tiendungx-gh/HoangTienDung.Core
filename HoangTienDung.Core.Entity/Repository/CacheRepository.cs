using AutoMapper;
using HoangTienDung.Core.Entity.Entity;
using HoangTienDung.Core.Entity.IRepository;
using HoangTienDung.Core.Entity.Model;
using Microsoft.Extensions.Caching.Distributed;
using SharpCompress.Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace HoangTienDung.Core.Entity.Repository
{
    public class CacheRepository<TEntity> : ICacheRepository<TEntity> where TEntity : CacheModel
    {
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        public CacheRepository(IDistributedCache cache, IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _cache.SetAsync(entity.Key, ObjectToByteArray(entity.Value));
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _cache.RemoveAsync(entity.Key);
        }

        public async Task<TEntity> GetByKeyAsync(string Key)
        {
            return _mapper.Map<TEntity>(new CacheModel(Key, await _cache.GetAsync(Key)));
        }

        private byte[] ObjectToByteArray(object obj)
        {

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
