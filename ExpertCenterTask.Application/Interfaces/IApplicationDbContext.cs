using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<PriceList> PriceLists { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Column> Columns { get; set; }
        DbSet<PriceListProduct> PriceListProducts { get; set; }
        DbSet<PriceListColumn> PriceListColumns { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}