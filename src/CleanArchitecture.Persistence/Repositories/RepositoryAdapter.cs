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
    public class RepositoryAdapter<T> : 
        IRepository<T> where T : class, IDomainEntity

    {
        readonly DbSet<T> _dbSet;
        public RepositoryAdapter(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbSet.AsNoTracking().Where(criteria).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(criteria);
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public void Insert(T item)
        {
            if (item != null)
            {
                _dbSet.Add(item);
            }
        }

        public void Update(T item)
        {
            var entry = _dbSet.Attach(item);
            entry.State = EntityState.Modified;
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
