using ExpertCenterTask.Application.Dto.Column;
using ExpertCenterTask.Application.Dto.PriceList;
using ExpertCenterTask.Application.Dto.PriceListColumn;
using ExpertCenterTask.Application.Dto.PriceListProduct;
using ExpertCenterTask.Application.Dto.Product;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExpertCenterTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.ServicesInit();

            return services;
        }

        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<IPriceListService<PriceListDto, PriceListDetailDto, CreatePriceListDto, UpdatePriceListDto>, PriceListService>();
            services.AddScoped<IBaseService<ProductDto, CreateProductDto, UpdateProductDto>, ProductService>();
            services.AddScoped<IBaseService<PriceListColumnDto, CreatePriceListColumnDto, UpdatePriceListColumnDto>, PriceListColumnService>();
            services.AddScoped<IBaseService<PriceListProductDto, CreatePriceListProductDto, UpdatePriceListProductDto>, PriceListProductService>();
            services.AddScoped<IBaseService<ColumnDto, CreateColumnDto, UpdateColumnDto>, ColumnService>();


        }
    }
}
