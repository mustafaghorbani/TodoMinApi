using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoMinApi.Domain.Domain;

namespace TodoMinApi.Repositories.Map
{
    public class TodoMap : IEntityTypeConfiguration<Todo>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("TodoItem");
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);
        }

        #endregion
    }
}
