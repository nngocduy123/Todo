using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Todo.Data.Entities;

namespace Todo.Data.Constract
{
    public interface IDbContext : IDisposable
	{
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

