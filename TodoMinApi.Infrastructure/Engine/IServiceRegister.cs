using Microsoft.Extensions.DependencyInjection;

namespace TodoMinApi.Infrastructure.Engine
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IServiceRegister" />.
    /// </summary>
    public interface IServiceRegister
    {
        #region Methods

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="service">The service<see cref="IServiceCollection"/>.</param>
        void Configure(IServiceCollection service);

        #endregion
    }

    #endregion
}
