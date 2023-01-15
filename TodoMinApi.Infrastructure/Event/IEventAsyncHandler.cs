namespace TodoMinApi.Infrastructure.Event
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IEventAsyncHandler{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IEventAsyncHandler<in T> where T : IEvent
    {
        #region Methods

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task HandleAsync(T domainEvent);

        #endregion
    }

    #endregion
}
