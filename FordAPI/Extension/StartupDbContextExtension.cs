using FordInternHW1.Data;
using Microsoft.EntityFrameworkCore;

namespace FordInternHW1.Web.Extension
{
    public static class StartupDbContextExtension
    {
        public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbtype = configuration.GetConnectionString("DbType");
            
            var dbConfig = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfig));
            
        }
    }
}
