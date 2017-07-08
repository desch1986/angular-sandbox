
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AngularSandbox.Repositories.EntityFramework
{
    internal interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
