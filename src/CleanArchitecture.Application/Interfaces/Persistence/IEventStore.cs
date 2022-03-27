using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IEventStore
    {
        Task Emit<TEntity, TChanges>(Guid id, string eventName, TChanges changes)
            where TEntity : class, IDomainEntity
            where TChanges: class, IDomainEventChanges;

        TEntity Load<TEntity>(Guid id, int from = 0)
            where TEntity : class, IDomainEntity;
    }
}
