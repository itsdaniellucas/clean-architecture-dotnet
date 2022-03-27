using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IDomainEvent<TEntity, TChanges> : IDomainEvent
                    where TEntity: IDomainEntity 
                    where TChanges: IDomainEventChanges
    {
        TEntity Apply(TEntity model, TChanges changes);
    }

    public interface IDomainEvent
    {

    }
}
