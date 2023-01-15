using Microsoft.Extensions.DependencyInjection;
using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Infrastructure.Engine.Register
{
    /// <summary>
    /// Defines the <see cref="CqrCommandConfiguration" />.
    /// </summary>
    public static class CqrCommandConfiguration
    {
        #region Methods

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="service">The service<see cref="IServiceCollection"/>.</param>
        public static void RegisterCqrCommand(this IServiceCollection service)
            => service.AddScoped<ICommandDispatcher, CommandDispatcher>();

        #endregion
    }
}
