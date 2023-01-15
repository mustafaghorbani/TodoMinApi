using Microsoft.Extensions.DependencyInjection;
using TodoMinApi.Infrastructure.Engine;
using TodoMinApi.Infrastructure.Repository;

namespace TodoMinApi.Repositories.Engine
{
    public class RepositoryRegister : IServiceRegister
    {
        public int Order => 0;

        public void Configure(IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<,,,>), typeof(Repository<,,,>));
        }
    }
}
