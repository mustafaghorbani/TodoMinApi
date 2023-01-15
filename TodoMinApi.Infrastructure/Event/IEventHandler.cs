

namespace TodoMinApi.Infrastructure.Event
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="ICommandHandler{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IEventHandler<in T> where T : IEvent
    {
        #region Methods

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        void Handle(T domainEvent);

        #endregion
    }

    #endregion
}
