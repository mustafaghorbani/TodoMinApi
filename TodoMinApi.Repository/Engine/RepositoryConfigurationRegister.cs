using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoMinApi.Repositories.Engine
{
    public class RepositoryConfigurationRegister //: IConfigurationRegister
    {
        public int Order => 0;

        public void Configure(IServiceCollection service, IConfiguration configuration)
        {
            //service.AddDbContext<DbContext.TodoDbConetxt>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("AppContextSqlConn")));

            //service.AddDbContext<AppReplicaContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("AppReplicaContextSqlConn")));
        }
    }
}
