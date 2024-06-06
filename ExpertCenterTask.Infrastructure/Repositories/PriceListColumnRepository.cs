using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Repositories
{
    public class PriceListColumnRepository : IBaseRepository<PriceListColumn>
    {
        private readonly IApplicationDbContext _db;

        public PriceListColumnRepository(IApplicationDbContext db) => _db = db;

        public async Task<List<PriceListColumn>> GetAll(CancellationToken cancellationToken = default) => await _db.PriceListColumns
            .AsNoTracking()
            .OrderBy(p => p.PriceListId)
            .Include(p => p.PriceList)
            .Include(p => p.Column)
            .ToListAsync(cancellationToken);

        public async Task<PriceListColumn> GetById(int id, CancellationToken cancellationToken = default) => await _db.PriceListColumns
              .AsNoTracking()
            .Include(p => p.PriceList)
            .Include(p => p.Column)
            .FirstOrDefaultAsync(p => p.PriceListId == id, cancellationToken);


        public async Task<PriceListColumn> Create(PriceListColumn entity, CancellationToken cancellationToken = default)
        {
            await _db.PriceListColumns.AddAsync(entity, cancellationToken);

            await _db.PriceListColumns.Entry(entity).Reference(p => p.PriceList).LoadAsync(cancellationToken);
            await _db.PriceListColumns.Entry(entity).Reference(p => p.Column).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task<PriceListColumn> Update(PriceListColumn entity, CancellationToken cancellationToken = default)
        {
            _db.PriceListColumns.Update(entity);

            await _db.PriceListColumns.Entry(entity).Reference(p => p.PriceList).LoadAsync(cancellationToken);
            await _db.PriceListColumns.Entry(entity).Reference(p => p.Column).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(PriceListColumn entity) => _db.PriceListColumns.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}