using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoMinApi.Infrastructure.Engine
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IConfigurationRegister" />.
    /// </summary>
    public interface IConfigurationRegister
    {
        #region Properties

        /// <summary>
        /// Gets the Order.
        /// </summary>
        int Order { get; }

        #endregion

        #region Methods

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="service">The service<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        void Configure(IServiceCollection service, IConfiguration configuration);

        #endregion
    }

    #endregion
}
