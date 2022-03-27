using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IRepository<T> : IRepository
        where T : class, IDomainEntity
    {
        void Insert(T item);
        void Update(T item);
        void Remove(T item);

        IQueryable<T> Query();
        Task<T> FindAsync(Expression<Func<T, bool>> criteria);
        Task<T> FindByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> GetAllAsync();
    }

    public interface IRepository
    {

    }
}
