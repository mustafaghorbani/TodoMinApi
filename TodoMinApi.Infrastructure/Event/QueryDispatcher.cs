namespace TodoMinApi.Infrastructure.Event
{
    /// <summary>
    /// Defines the <see cref="QueryDispatcher" />.
    /// </summary>
    public class QueryDispatcher : IQueryDispatcher
    {
        #region Fields

        /// <summary>
        /// Defines the serviceProvider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryDispatcher"/> class.
        /// </summary>
        /// <param name="provider">The provider<see cref="IServiceProvider"/>.</param>
        public QueryDispatcher(IServiceProvider provider) => serviceProvider = provider;

        #endregion

        #region Methods

        /// <summary>
        /// The Execute.
        /// </summary>
        /// <typeparam name="TQuery">.</typeparam>
        /// <typeparam name="TResult">.</typeparam>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="TResult"/>.</returns>
        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery
            => ((IQueryHandler<TQuery, TResult>)serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>))).Execute(query);

        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <typeparam name="TQuery">.</typeparam>
        /// <typeparam name="TResult">.</typeparam>
        /// <param name="query">The query<see cref="TQuery"/>.</param>
        /// <returns>The <see cref="TResult"/>.</returns>
        public async Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
            => await ((IQueryHandler<TQuery, TResult>)serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>))).ExecuteAsync(query);

        #endregion
    }
}
