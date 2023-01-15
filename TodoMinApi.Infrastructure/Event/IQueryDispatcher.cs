namespace TodoMinApi.Infrastructure.Event
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IQueryDispatcher" />.
    /// </summary>
    public interface IQueryDispatcher
    {
        #region Methods

        /// <summary>
        /// The Execute.
        /// </summary>
        /// <typeparam name="TQuery">.</typeparam>
        /// <typeparam name="TResult">.</typeparam>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="TResult"/>.</returns>
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery;

        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <typeparam name="TQuery">.</typeparam>
        /// <typeparam name="TResult">.</typeparam>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="Task{TResult}"/>.</returns>
        Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;

        #endregion
    }

    #endregion
}
