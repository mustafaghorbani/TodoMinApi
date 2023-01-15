

namespace TodoMinApi.Infrastructure.Event
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="ICommandHandler{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface ICommandHandler<in T> where T : ICommand
    {
        #region Methods

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        void Handle(T command);

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task HandleAsync(T command);

        #endregion
    }

    #endregion
}
