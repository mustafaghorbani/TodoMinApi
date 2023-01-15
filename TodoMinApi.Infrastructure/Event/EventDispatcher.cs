
using Microsoft.Extensions.DependencyInjection;

namespace TodoMinApi.Infrastructure.Event
{
    /// <summary>
    /// Defines the <see cref="EventDispatcher" />.
    /// </summary>
    public class EventDispatcher : IEventDispatcher
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
        public EventDispatcher(IServiceProvider provider) => this.provider = provider;

        #endregion

        #region Methods

        /// <summary>
        /// The Raise.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        public void Raise<T>(T domainEvent) where T : IEvent
            => provider.GetServices(typeof(IEventHandler<T>)).ToList().ForEach(x => ((IEventHandler<T>)x).Handle(domainEvent));

        /// <summary>
        /// The RaiseAsyncEvent.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="domainEvent">The domainEvent<see cref="T"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task RaiseAsync<T>(T domainEvent) where T : IEvent
        {
            var tasks = provider.GetServices(typeof(IEventAsyncHandler<T>))?.Select(x => ((IEventAsyncHandler<T>)x).HandleAsync(domainEvent));
            await Task.WhenAll(tasks);
        }

        #endregion
    }
}
