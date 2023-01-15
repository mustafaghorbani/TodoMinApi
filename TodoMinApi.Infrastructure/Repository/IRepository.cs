using TodoMinApi.Infrastructure.Entity;

namespace TodoMinApi.Infrastructure.Repository
{
    public interface IRepository<TDbcontext, T, TId, TUserId> :
        IReadOnlyRepository<TDbcontext, T, TId>,
        IWriteOnlyRepository<TDbcontext, T, TId>
        where TDbcontext : Microsoft.EntityFrameworkCore.DbContext
        where T : IBaseEntity<TId>
    {
    }
}
