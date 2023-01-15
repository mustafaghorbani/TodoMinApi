using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoMinApi.Domain.Domain;

namespace TodoMinApi.Repositories.Map
{
    public class TodoUserMap : IEntityTypeConfiguration<TodoUser>
    {
        public void Configure(EntityTypeBuilder<TodoUser> builder)
        {
            builder.ToTable(nameof(TodoUser));
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.UserName).HasMaxLength(30);
            //builder.Property(x => x.UserName).HasMaxLength(30).IsUnicode(false);
            //builder.Property(x => x.Password).HasMaxLength(20).IsUnicode(false);
        }
    }
}
