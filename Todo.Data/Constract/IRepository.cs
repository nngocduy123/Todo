using System.Linq.Expressions;

namespace Todo.Data.Constract
{
    public interface IRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> criteria = null);
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int Id);
        Task SaveChanges();
    }
}