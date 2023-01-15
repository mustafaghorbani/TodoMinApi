namespace TodoMinApi.Infrastructure.Entity
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IBaseEntity{TId}" />.
    /// </summary>
    /// <typeparam name="TId">.</typeparam>
    public interface IBaseEntity<TId>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        TId Id { get; set; }

        #endregion
    }

    #endregion
}
