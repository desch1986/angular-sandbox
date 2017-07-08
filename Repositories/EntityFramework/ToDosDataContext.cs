using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AngularSandbox.Repositories.Entities;

namespace AngularSandbox.Repositories.EntityFramework
{
    public class BasicDataContext : DbContext, IDbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        EntityEntry<TEntity> IDbContext.Entry<TEntity>(TEntity entity)
        {
            return Entry<TEntity>(entity);
        }

        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("DataSource=Database.db");
        }

        Task<int> IDbContext.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }
    }
}