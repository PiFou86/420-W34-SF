using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DemoEF_DALApplicationDBContext
{
    public static class DALDbContextGeneration
    {
        private static DbContextOptions<ApplicationDBContext> _dbContextOptions;
        private static PooledDbContextFactory<ApplicationDBContext> _pooledDbContextFactory;
        static DALDbContextGeneration()
        {
            IConfigurationRoot configuration =
                 new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseOracle(configuration.GetConnectionString("PersonnesConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
#if DEBUG
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                .EnableSensitiveDataLogging()
#endif
                .Options;
            _pooledDbContextFactory = new PooledDbContextFactory<ApplicationDBContext>(_dbContextOptions);
        }
        public static ApplicationDBContext ObtenirApplicationDBContext()
        {
            return _pooledDbContextFactory.CreateDbContext();
        }
    }
}
