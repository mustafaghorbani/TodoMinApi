namespace TodoMinApi.Infrastructure.Entity
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IEntity{TId, TUserId}" />.
    /// </summary>
    /// <typeparam name="TId">.</typeparam>
    /// <typeparam name="TUserId">.</typeparam>
    public interface IEntity<TId, TUserId> : IBaseEntity<TId>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        TUserId CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate.
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the IsActive
        /// Gets or sets a value indicating whether IsActive..
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy.
        /// </summary>
        TUserId UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedDate.
        /// </summary>
        DateTime? UpdatedDate { get; set; }

        #endregion
    }

    #endregion
}
