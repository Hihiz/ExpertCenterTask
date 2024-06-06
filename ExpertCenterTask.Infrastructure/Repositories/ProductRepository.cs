using ExpertCenterTask.Application.Interfaces;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertCenterTask.Infrastructure.Repositories
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly IApplicationDbContext _db;

        public ProductRepository(IApplicationDbContext db) => _db = db;

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken = default) => await _db.Products
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);

        public async Task<Product> GetById(int id, CancellationToken cancellationToken = default) => await _db.Products
             .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<Product> Create(Product entity, CancellationToken cancellationToken = default)
        {
            await _db.Products.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<Product> Update(Product entity, CancellationToken cancellationToken = default)
        {
            _db.Products.Update(entity);

            return entity;
        }

        public async Task Delete(Product entity) => _db.Products.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}
