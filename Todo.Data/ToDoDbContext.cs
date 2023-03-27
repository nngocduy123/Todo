using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Todo.Data.Constract;
using Todo.Data.Entities;

namespace Todo.Data
{
    public class ToDoDbContext : DbContext, IDbContext
    {
        private string ConnectionString { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

