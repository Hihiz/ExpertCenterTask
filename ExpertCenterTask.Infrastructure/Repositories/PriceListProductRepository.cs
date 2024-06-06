using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Repositories
{
    public class PriceListProductRepository : IBaseRepository<PriceListProduct>
    {
        private readonly IApplicationDbContext _db;

        public PriceListProductRepository(IApplicationDbContext db) => _db = db;

        public async Task<List<PriceListProduct>> GetAll(CancellationToken cancellationToken = default) => await _db.PriceListProducts
            .AsNoTracking()
            .OrderBy(p => p.PriceListId)
            .Include(p => p.PriceList)
            .Include(p => p.Product)
            .ToListAsync(cancellationToken);

        public async Task<PriceListProduct> GetById(int id, CancellationToken cancellationToken = default) => await _db.PriceListProducts
              .AsNoTracking()
            .Include(p => p.PriceList)
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.PriceListId == id, cancellationToken);


        public async Task<PriceListProduct> Create(PriceListProduct entity, CancellationToken cancellationToken = default)
        {
            await _db.PriceListProducts.AddAsync(entity, cancellationToken);

            await _db.PriceListProducts.Entry(entity).Reference(p => p.PriceList).LoadAsync(cancellationToken);
            await _db.PriceListProducts.Entry(entity).Reference(p => p.Product).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task<PriceListProduct> Update(PriceListProduct entity, CancellationToken cancellationToken = default)
        {
            _db.PriceListProducts.Update(entity);

            await _db.PriceListProducts.Entry(entity).Reference(p => p.PriceList).LoadAsync(cancellationToken);
            await _db.PriceListProducts.Entry(entity).Reference(p => p.Product).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(PriceListProduct entity) => _db.PriceListProducts.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}