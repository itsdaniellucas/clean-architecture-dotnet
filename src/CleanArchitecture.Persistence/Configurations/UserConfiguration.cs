using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                    .ValueGeneratedNever();

            builder.Ignore(i => i.TodoListIds);

            builder.HasMany(i => i.TodoLists)
                    .WithOne(i => i.User)
                    .HasForeignKey(i => i.UserId);
        }
    }
}
