

using Microsoft.Extensions.DependencyInjection;
using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Infrastructure.Engine.Register
{

    /// <summary>
    /// Defines the <see cref="CqrEventConfiguration" />.
    /// </summary>
    public static class CqrEventConfiguration
    {
        #region Methods

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="service">The service<see cref="IServiceCollection"/>.</param>
        public static void RegisterCqrEvent(this IServiceCollection service)
            => service.AddScoped<IEventDispatcher, EventDispatcher>();

        #endregion
    }
}
