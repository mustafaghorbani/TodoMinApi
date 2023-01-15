using TodoMinApi.Infrastructure.Entity;
using System.Linq.Expressions;

namespace TodoMinApi.Infrastructure.Repository
{
    public interface IReadOnlyRepository<TDbContext, T, TId> where T : IBaseEntity<TId> where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Methods

        IQueryable<T> All();

        bool Any(Expression<Func<T, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Get(TId id);

        Task<T> GetAsync(TId id);

        #endregion
    }
}