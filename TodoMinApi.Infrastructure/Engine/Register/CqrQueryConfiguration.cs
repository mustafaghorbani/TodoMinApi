

using Microsoft.Extensions.DependencyInjection;
using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Infrastructure.Engine.Register
{

    /// <summary>
    /// Defines the <see cref="CqrQueryConfiguration" />.
    /// </summary>
    public static class CqrQueryConfiguration
    {
        #region Methods

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="service">The service<see cref="IServiceCollection"/>.</param>
        public static void RegisterCqrQuery(this IServiceCollection service) =>
            service.AddScoped<IQueryDispatcher, QueryDispatcher>();

        #endregion
    }
}
