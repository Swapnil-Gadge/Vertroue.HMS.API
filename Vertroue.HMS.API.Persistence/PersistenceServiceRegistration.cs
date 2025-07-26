using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Persistence.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vertroue.HMS.API.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(new SqlConnection
                {
                    ConnectionString = configuration.GetConnectionString("CoreDbConnectionString"),
                }));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserMasterRepository, UserMasterRepository>();
            services.AddScoped<IDashBoardRepository, DashBoardRepository>();
            services.AddScoped<IBillingRepository, BillingRepository>();
            services.AddSingleton<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<ICorporateRepository, CorporateRepository>();
            services.AddScoped<IQMSDataRepository, QMSDataRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            return services;    
        }        
    }
}
