using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Repositories
{
    public class PriceListRepository : IBaseRepository<PriceList>
    {
        private readonly IApplicationDbContext _db;

        public PriceListRepository(IApplicationDbContext db) => _db = db;

        public async Task<List<PriceList>> GetAll(CancellationToken cancellationToken = default) => await _db.PriceLists
            .AsNoTracking()
            .Include(p => p.PriceListProducts).ThenInclude(p => p.Product)
            .Include(p => p.PriceListColumns).ThenInclude(p => p.Column)
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);


        public async Task<PriceList> GetById(int id, CancellationToken cancellationToken = default) => await _db.PriceLists
            .AsNoTracking()
         .Include(p => p.PriceListProducts).ThenInclude(p => p.Product)
            .Include(p => p.PriceListColumns).ThenInclude(p => p.Column)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);


        public async Task<PriceList> Create(PriceList entity, CancellationToken cancellationToken = default)
        {
            await _db.PriceLists.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<PriceList> Update(PriceList entity, CancellationToken cancellationToken = default)
        {
            _db.PriceLists.Update(entity);

            return entity;
        }

        public async Task Delete(PriceList entity) => _db.PriceLists.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }

}
