using TodoMinApi.Infrastructure.Entity;

namespace TodoMinApi.Infrastructure.Repository
{
    public interface IWriteOnlyRepository<TDbcontext, T, TId> where T : IBaseEntity<TId> where TDbcontext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Methods

        TId Add(T entity);

        Task<TId> AddAsync(T entity);

        ICollection<T> Add(ICollection<T> entities);

        Task<ICollection<T>> AddAsync(ICollection<T> entities);

        int Delete(T entity);

        bool Delete(TId key);

        void Delete(ICollection<T> entities);

        Task DeleteAsync(ICollection<T> entities);

        Task<int> DeleteAsync(T entity);

        Task<bool> DeleteAsync(TId key);

        ICollection<T> Update(ICollection<T> entities);

        T Update(TId key, T entity);

        Task<T> UpdateAsync(TId key, T entity);

        Task<ICollection<T>> UpdateAsync(ICollection<T> entities);


        #endregion

    }
}
