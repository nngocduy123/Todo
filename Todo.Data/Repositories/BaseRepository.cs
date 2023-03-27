using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.Data.Constract;
using Todo.Data.Entities;

namespace Todo.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext context;

        public DbSet<TEntity> DbSet { get; set; }

        public BaseRepository(IDbContext context)
        {
            this.context = context;
            DbSet = this.context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> criteria = null)
        {

            return criteria == null ? DbSet : DbSet.Where(criteria);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task Delete(int Id)
        {
            var original = await DbSet.FindAsync(Id);

            if (original != null)
            {
                DbSet.Remove(original);
            }
        }
        // Need to add update specify properties
        public async Task Update(TEntity entity)
        {
            var original = await DbSet.FindAsync(entity.Id);

            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(entity);
            }

        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

    }
}

