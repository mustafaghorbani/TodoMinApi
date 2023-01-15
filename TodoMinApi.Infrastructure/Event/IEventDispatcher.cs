namespace TodoMinApi.Infrastructure.Event
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IEventDispatcher" />.
    /// </summary>
    public interface IEventDispatcher
    {
        #region Methods

        /// <summary>
        /// The Raise.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        void Raise<T>(T domainEvent) where T : IEvent;

        /// <summary>
        /// The RaiseAsyncEvent.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task RaiseAsync<T>(T domainEvent) where T : IEvent;

        #endregion
    }

    #endregion
}
