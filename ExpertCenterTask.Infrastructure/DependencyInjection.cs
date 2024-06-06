using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using ExpertCenterTask.Infrastructure.Data;
using ExpertCenterTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertCenterTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.RepositoriesInit();

            return services;
        }

        public static void RepositoriesInit(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<PriceList>, PriceListRepository>();
            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
            services.AddScoped<IBaseRepository<Column>, ColumnRepository>();
            services.AddScoped<IBaseRepository<PriceListColumn>, PriceListColumnRepository>();
            services.AddScoped<IBaseRepository<PriceListProduct>, PriceListProductRepository>();
        }
    }
}
