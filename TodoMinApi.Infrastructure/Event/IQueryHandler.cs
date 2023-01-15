namespace TodoMinApi.Infrastructure.Event
{

    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IQueryHandler{TResult}" />.
    /// </summary>
    /// <typeparam name="TQuery">.</typeparam>
    /// <typeparam name="TResult">.</typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        #region Methods

        /// <summary>
        /// The Execute.
        /// </summary>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="TResult"/>.</returns>
        TResult Execute(TQuery query);

        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="Task{TResult}"/>.</returns>
        Task<TResult> ExecuteAsync(TQuery query);

        #endregion
    }

    #endregion
}
