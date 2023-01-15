
using TodoMinApi.Infrastructure.Entity;

namespace Tn.Activation.Infrastructure.Extensions
{
    /// <summary>
    /// Defines the <see cref="EntityExtensions" />.
    /// </summary>
    public static class EntityExtension
    {
        #region Methods

        /// <summary>
        /// The AddEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entities">The entities<see cref="ICollection{IEntity{TId, TUserId}}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void AddEntity<T, TId, TUserId>(this ICollection<T> entities, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            foreach (var entity in entities)
            {
                entity.AddEntity<T, TId, TUserId>(userId, dateTime);
            }
        }

        /// <summary>
        /// The AddEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entity">The entity<see cref="IEntity{TId, TUserId}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void AddEntity<T, TId, TUserId>(this T entity, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            entity.IsDeleted = true;
            entity.CreatedBy = userId;
            entity.CreatedDate = dateTime;
        }

        /// <summary>
        /// The SoftDeleteEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entities">The entities<see cref="ICollection{IEntity{TId, TUserId}}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void SoftDeleteEntity<T, TId, TUserId>(this ICollection<T> entities, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            foreach (var entity in entities)
            {
                entity.SoftDeleteEntity<T, TId, TUserId>(userId, dateTime);
            }
        }

        /// <summary>
        /// The SoftDeleteEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entity">The entity<see cref="IEntity{TId, TUserId}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void SoftDeleteEntity<T, TId, TUserId>(this T entity, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            entity.IsDeleted = false;
            entity.UpdatedBy = userId;
            entity.UpdatedDate = dateTime;
        }

        /// <summary>
        /// The UpdateEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entities">The entities<see cref="ICollection{IEntity{TId, TUserId}}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void UpdateEntity<T, TId, TUserId>(this ICollection<T> entities, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            foreach (var entity in entities)
            {
                entity.UpdateEntity<T, TId, TUserId>(userId, dateTime);
            }
        }

        /// <summary>
        /// The UpdateEntity.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <typeparam name="TId">.</typeparam>
        /// <typeparam name="TUserId">.</typeparam>
        /// <param name="entity">The entity<see cref="IEntity{TId, TUserId}"/>.</param>
        /// <param name="userId">The userId<see cref="TUserId"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="DateTime"/>.</param>
        public static void UpdateEntity<T, TId, TUserId>(this T entity, TUserId userId, DateTime dateTime) where T : IEntity<TId, TUserId>
        {
            entity.UpdatedBy = userId;
            entity.UpdatedDate = dateTime;
        }

        #endregion
    }
}
