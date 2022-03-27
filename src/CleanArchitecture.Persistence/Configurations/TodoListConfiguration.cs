using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable(nameof(TodoList));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                    .ValueGeneratedNever();

            builder.Ignore(i => i.TodoIds);

            builder.HasMany(i => i.Todos)
                    .WithOne(i => i.TodoList)
                    .HasForeignKey(i => i.TodoListId);

            builder.HasOne(i => i.User)
                    .WithMany(i => i.TodoLists)
                    .HasForeignKey(i => i.UserId);
        }
    }
}
