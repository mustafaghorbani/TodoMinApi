
using Microsoft.Extensions.DependencyInjection;

namespace TodoMinApi.Infrastructure.Event
{
    /// <summary>
    /// Defines the <see cref="CommandDispatcher" />.
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        #region Fields

        /// <summary>
        /// Defines the provider.
        /// </summary>
        private readonly IServiceProvider provider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDispatcher"/> class.
        /// </summary>
        /// <param name="provider">The provider<see cref="IServiceProvider"/>.</param>
        public CommandDispatcher(IServiceProvider provider) => this.provider = provider;

        #endregion

        #region Methods

        /// <summary>
        /// The Raise.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        public void Raise<T>(T command) where T : ICommand
            => provider.GetServices(typeof(ICommandHandler<T>)).ToList().ForEach(x => ((ICommandHandler<T>)x).Handle(command));

        /// <summary>
        /// The RaiseAsyncEvent.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task RaiseAsync<T>(T command) where T : ICommand
        {
            var tasks = provider.GetServices(typeof(ICommandHandler<T>))?.Select(x => ((ICommandHandler<T>)x).HandleAsync(command));
            await Task.WhenAll(tasks);
        }

        #endregion
    }
}
