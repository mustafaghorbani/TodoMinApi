

namespace TodoMinApi.Infrastructure.Entity
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IUser{TId}" />.
    /// </summary>
    /// <typeparam name="TId">.</typeparam>
    public interface IUser<TId> : IBaseEntity<TId>
    {
    }

    #endregion
}
