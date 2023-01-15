using TodoMinApi.Infrastructure.Entity;
using Tn.Activation.Infrastructure.Extensions;

namespace TodoMinApi.Infrastructure.Repository
{
    public class Repository<TDbcontext, T, TId, TUserId> :
        ReadOnlyRepository<TDbcontext, T, TId>,
        IRepository<TDbcontext, T, TId, TUserId>
        where TDbcontext : Microsoft.EntityFrameworkCore.DbContext
        where T : class, IEntity<TId, TUserId>
    {
        #region Fields

        /// <summary>
        /// Defines the user.
        /// </summary>
        private readonly IUser<TUserId> user;

        #endregion

        #region Constructors


        public Repository(TDbcontext context, IUser<TUserId> user) : base(context)
            => this.user = user;

        #endregion

        #region Methods

        /// <summary>
        /// The Add.
        /// </summary>
        /// <param name="entities">The entities<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="ICollection{TId}"/>.</returns>
        public ICollection<T> Add(ICollection<T> entities)
        {
            entities.AddEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.AddRange(entities);
            context.SaveChanges();

            return entities;
        }

        /// <summary>
        /// The Add.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="TId"/>.</returns>
        public TId Add(T entity)
        {
            entity.AddEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }

        /// <summary>
        /// The AddAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="IEnumerable{T}"/>.</param>
        /// <returns>The <see cref="Task{ICollection{TId}}"/>.</returns>
        public async Task<ICollection<T>> AddAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return entities;
            }

            entities.AddEntity<T, TId, TUserId>(user.Id, DateTime.Now);

            await Table.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            return entities;
        }

        /// <summary>
        /// The AddAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task{TId}"/>.</returns>
        public async Task<TId> AddAsync(T entity)
        {
            entity.AddEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Add(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entities">The entities<see cref="ICollection{T}"/>.</param>
        public void Delete(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            entities.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);

            Table.UpdateRange(entities);
            context.SaveChanges();
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Delete(T entity)
        {
            entity.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);

            return context.SaveChanges();
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="key">The key<see cref="TId"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Delete(TId key)
        {
            var entity = Table.Find(key);

            if (entity == null)
            {
                return false;
            }

            entity.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);

            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            entities.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.UpdateRange(entities);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public async Task<int> DeleteAsync(T entity)
        {
            entity.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);

            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="key">The key<see cref="TId"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> DeleteAsync(TId key)
        {
            var entity = await Table.FindAsync(key);

            if (entity == null)
            {
                return false;
            }

            entity.SoftDeleteEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);

            return await context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="entities">The entities<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="ICollection{T}"/>.</returns>
        public ICollection<T> Update(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return entities;
            }

            entities.UpdateEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.UpdateRange(entities);
            context.SaveChanges();

            return entities;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="key">The key<see cref="TId"/>.</param>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="T"/>.</returns>
        public T Update(TId key, T entity)
        {
            if (entity == null)
            {
                return null;
            }

            entity.UpdateEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);
            context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="entities">The entities<see cref="ICollection{T}"/>.</param>
        /// <returns>The <see cref="Task{ICollection{T}}"/>.</returns>
        public async Task<ICollection<T>> UpdateAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return entities;
            }

            entities.UpdateEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.UpdateRange(entities);
            await context.SaveChangesAsync();

            return entities;
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="key">The key<see cref="TId"/>.</param>
        /// <param name="entity">The entity<see cref="T"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public async Task<T> UpdateAsync(TId key, T entity)
        {
            if (entity == null)
            {
                return null;
            }

            entity.UpdateEntity<T, TId, TUserId>(user.Id, DateTime.Now);
            Table.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        #endregion
    }
}
