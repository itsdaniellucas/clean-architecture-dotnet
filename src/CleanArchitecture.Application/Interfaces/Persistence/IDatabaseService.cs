using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IDatabaseService
    {
        IRepository<Todo> Todos { get; }
        IRepository<TodoList> TodoLists { get; }
        IRepository<User> Users { get; }
        Task CommitAsync<T>() where T : class, IDomainEntity;
        IRepository<T> Repo<T>() where T : class, IDomainEntity;
    }
}
