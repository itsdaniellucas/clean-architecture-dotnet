using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Common.Interfaces;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<User> Users { get; set; }
        

        public async Task CommitAsync<T>() where T: class, IDomainEntity
        {
            var tableName = typeof(T).Name;

            //await this.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT dbo.{tableName} ON");
            await this.SaveChangesAsync();
            //await this.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT dbo.{tableName} OFF");
        }

        public DatabaseContext(IAppConfiguration config)
                    : base(config.GetDbContextOptions())
        {
            Database.EnsureCreated();
            Database.SetCommandTimeout(300);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // similar to modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>() in EF6
            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                rel.DeleteBehavior = DeleteBehavior.Restrict;

            
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new TodoListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            var dateNow = DateTime.Now;
            var userId = new Guid("cec6504b-ce22-49f9-b493-80a47556e0ba");


            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User() { Id = userId, Username = "Test", DateCreated = dateNow, DateModified = dateNow, CreatedBy = Guid.Empty, ModifiedBy = Guid.Empty, IsActive = true },
            });
        }

    }
}
