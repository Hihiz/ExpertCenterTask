using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Repositories
{
    public class ColumnRepository : IBaseRepository<Column>
    {
        private readonly IApplicationDbContext _db;

        public ColumnRepository(IApplicationDbContext db) => _db = db;

        public async Task<List<Column>> GetAll(CancellationToken cancellationToken = default) => await _db.Columns
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync(cancellationToken);

        public async Task<Column> GetById(int id, CancellationToken cancellationToken = default) => await _db.Columns
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<Column> Create(Column entity, CancellationToken cancellationToken = default)
        {
            await _db.Columns.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<Column> Update(Column entity, CancellationToken cancellationToken = default)
        {
            _db.Columns.Update(entity);

            return entity;
        }

        public async Task Delete(Column entity) => _db.Columns.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}
