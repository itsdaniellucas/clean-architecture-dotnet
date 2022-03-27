using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Todo> Todos { get; set; }
        DbSet<TodoList> TodoLists { get; set; }
        DbSet<User> Users { get; set; }
        Task CommitAsync<T>() where T : class, IDomainEntity;
    }
}
