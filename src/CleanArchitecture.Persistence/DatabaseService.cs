using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Persistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public class DatabaseService : IDatabaseService
    {
        readonly IDatabaseContext _context;
        readonly RepositoryAdapter<Todo> _todoRepo;
        readonly RepositoryAdapter<TodoList> _todoListRepo;
        readonly RepositoryAdapter<User> _userRepo;

        readonly ConcurrentDictionary<Type, IRepository> _repoMap;

        public IRepository<Todo> Todos { get { return _todoRepo; } }
        public IRepository<TodoList> TodoLists { get { return _todoListRepo; } }
        public IRepository<User> Users { get { return _userRepo; } }


        public DatabaseService(IDatabaseContext context)
        {
            _context = context;
            _todoRepo = new RepositoryAdapter<Todo>(_context.Todos);
            _todoListRepo = new RepositoryAdapter<TodoList>(_context.TodoLists);
            _userRepo = new RepositoryAdapter<User>(_context.Users);

            _repoMap = new ConcurrentDictionary<Type, IRepository>();
            _repoMap.TryAdd(typeof(Todo), _todoRepo);
            _repoMap.TryAdd(typeof(TodoList), _todoListRepo);
            _repoMap.TryAdd(typeof(User), _userRepo);
        }

        public async Task CommitAsync<T>()
            where T: class, IDomainEntity
        {
            await _context.CommitAsync<T>();
        }

        public IRepository<T> Repo<T>()
            where T : class, IDomainEntity
        {

            IRepository repo;
            if (_repoMap.TryGetValue(typeof(T), out repo))
                return repo as IRepository<T>;
;           return null;
        }
    }
}
