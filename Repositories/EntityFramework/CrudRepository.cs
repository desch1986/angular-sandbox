using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularSandbox.Repositories.Entities;

namespace AngularSandbox.Repositories.EntityFramework
{
    internal class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _dbContext;

        public CrudRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<ToDoItem> TimeAcquisition { get; set; }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return (entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
             _dbContext.Set<TEntity>().Remove(entity);
             await _dbContext.SaveChangesAsync()
                               .ConfigureAwait(false);
        }

        public IQueryable<TEntity> ReadAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync()
                            .ConfigureAwait(false);

            return entity;
        }
    }
}
