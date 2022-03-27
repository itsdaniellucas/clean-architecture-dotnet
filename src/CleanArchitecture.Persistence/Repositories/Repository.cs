using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class Repository<T> : DbSet<T>, IRepository<T> where T : class, IDomainEntity
    {
        public IQueryable<T> Query()
        {
            return this;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await base.AsQueryable().Where(criteria).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            return await base.AsQueryable().FirstOrDefaultAsync(criteria);
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await base.AsQueryable().SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await base.AsQueryable().ToListAsync();
        }

        public void Insert(T item)
        {
            if(item != null)
            {
                base.Add(item);
            }
        }

        public void Update(T item)
        {
            var entry = base.Attach(item);
            entry.Property(i => i.DateCreated).IsModified = false;
            entry.Property(i => i.CreatedBy).IsModified = false;
        }

        public void Remove(T item)
        {
            item.IsActive = false;
            this.Update(item);
        }
    }
}
