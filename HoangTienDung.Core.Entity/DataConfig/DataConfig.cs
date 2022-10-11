using HoangTienDung.Core.Entity.Constant;
using HoangTienDung.Core.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HoangTienDung.Core.Entity.DataConfig
{
    public static class DataConfig
    {
        public static void AddSQLContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(config.GetConnectionString("SQLConnection")));
        }
        public static void AddMongoContext(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbSettings>(option => config.GetConnectionString("MongoConnection"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
        public static void AddCacheContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options => config.GetConnectionString("RedisConnection"));
        }
    }
}
