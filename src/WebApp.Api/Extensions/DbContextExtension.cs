using Microsoft.EntityFrameworkCore;
using WebApp.Api.Constants;
using WebApp.Data.DbContexts;

namespace WebApp.Api.Extensions
{
    public static class DbContextExtension
    {
        internal static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            SetReadOnlyDbContext(services, configuration);
            SetWritableDbContext(services, configuration);
        }

        private static void SetReadOnlyDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var readOnlyDbConnectionString = configuration.GetConnectionString(ConnectionString.ReadonlyDb);
            services.AddDbContext<ReadonlyDbContext>(options => { options.UseSqlServer(readOnlyDbConnectionString); });
        }

        private static void SetWritableDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var writableDbConnectionString = configuration.GetConnectionString(ConnectionString.WritableDb);
            services.AddDbContext<WritableDbContext>(options => { options.UseSqlServer(writableDbConnectionString); });
        }
    }
}