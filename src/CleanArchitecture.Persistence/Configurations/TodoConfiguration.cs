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
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable(nameof(Todo));

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                    .ValueGeneratedNever();

            builder.HasOne(i => i.TodoList)
                    .WithMany(i => i.Todos)
                    .HasForeignKey(i => i.TodoListId);
        }
    }
}
