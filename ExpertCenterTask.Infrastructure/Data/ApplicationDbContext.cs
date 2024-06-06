using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<PriceListProduct> PriceListProducts { get; set; }
        public DbSet<PriceListColumn> PriceListColumns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceListProduct>()
                .HasKey(pl => new { pl.PriceListId, pl.ProductId });

            modelBuilder.Entity<PriceListProduct>()
                .HasOne(pl => pl.PriceList)
                .WithMany(o => o.PriceListProducts)
                .HasForeignKey(pl => pl.PriceListId);

            modelBuilder.Entity<PriceListProduct>()
                .HasOne(pl => pl.Product)
                .WithMany(p => p.PriceListProducts)
                .HasForeignKey(pl => pl.ProductId);

            modelBuilder.Entity<PriceListColumn>()
              .HasKey(pl => new { pl.PriceListId, pl.ColumnId });

            modelBuilder.Entity<PriceListColumn>()
                .HasOne(pl => pl.PriceList)
                .WithMany(o => o.PriceListColumns)
                .HasForeignKey(pl => pl.PriceListId);

            modelBuilder.Entity<PriceListColumn>()
                .HasOne(oe => oe.Column)
                .WithMany(e => e.PriceListColumns)
                .HasForeignKey(oe => oe.ColumnId);
        }
    }
}
