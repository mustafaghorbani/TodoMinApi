using Microsoft.EntityFrameworkCore;
using TodoMinApi.Infrastructure.Entity;
using System.Linq.Expressions;
using System.Transactions;

namespace TodoMinApi.Infrastructure.Repository
{
    public class ReadOnlyRepository<TDbContext, T, TId> :
        IReadOnlyRepository<TDbContext, T, TId>
        where TDbContext : Microsoft.EntityFrameworkCore.DbContext
        where T : class, IBaseEntity<TId>
    {
        #region Fields

        protected readonly TDbContext context;

        /// <summary>
        /// Defines the entities.
        /// </summary>
        private DbSet<T> entities;

        #endregion

        #region Constructors


        public ReadOnlyRepository(TDbContext context)
            => this.context = context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Table.
        /// </summary>
        protected DbSet<T> Table => entities ?? (entities = context.Set<T>());

        #endregion

        #region Methods

        private static TransactionScope CreateNoLockTransaction()
        {
            var options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
            return new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
        }

        public virtual IQueryable<T> All()
        {
            return Table;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            using (CreateNoLockTransaction())
            {
                return Table.Any(filter);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.AnyAsync(filter);
            }
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return Table.SingleOrDefault(match);
            }
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.SingleOrDefaultAsync(match);
            }
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return Table.Where(match).ToList();
            }
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.Where(match).ToListAsync();
            }
        }

        public T Get(TId id)
        {
            using (CreateNoLockTransaction())
            {
                return Table.Find(id);
            }
        }

        public async Task<T> GetAsync(TId id)
        {
            using (CreateNoLockTransaction())
            {
                return await Table.FindAsync(id);
            }
        }

        #endregion
    }
}
