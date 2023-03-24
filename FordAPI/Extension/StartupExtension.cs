using FordInternHW1.Data;
using FordInternHW1.Data.Model;

namespace FordInternHW1.Web.Extension
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenericRepository<Staff>, GenericRepository<Staff>>();
        }
    }
}
