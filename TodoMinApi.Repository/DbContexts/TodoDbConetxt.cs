
using Microsoft.EntityFrameworkCore;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Repositories.Map;

namespace TodoMinApi.Repositories.DbContexts
{
    public class TodoDbConetxt : DbContext
    {
        #region Constructors
        public TodoDbConetxt(DbContextOptions<TodoDbConetxt> options) : base(options) { }


        #endregion

        #region Properties

        public DbSet<Todo> Todos => Set<Todo>();

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoMap());
        }

        #endregion
    }
}
