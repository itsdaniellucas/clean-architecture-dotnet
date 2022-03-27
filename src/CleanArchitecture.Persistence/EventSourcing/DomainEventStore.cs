using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.EventSourcing
{
    public class DomainEventStore
    {
        private static ConcurrentDictionary<string, Delegate> _domainEvents;

        static DomainEventStore()
        {
            _domainEvents = new ConcurrentDictionary<string, Delegate>();
        }

        public  static void Register<TEntity, TChanges>(string eventName, Func<TEntity, TChanges, TEntity> domainEvent)
            where TEntity : IDomainEntity
            where TChanges : IDomainEventChanges
        {
            if (!_domainEvents.ContainsKey(eventName))
                _domainEvents.TryAdd(eventName, domainEvent);
            else
                throw new ArgumentException($"DomainEvent: {eventName} is already registered.");
        }

        public static TEntity Apply<TEntity>(string eventName, TEntity obj, object changes)
            where TEntity : IDomainEntity
        {
            Delegate domainEvent = null;

            if (_domainEvents.TryGetValue(eventName, out domainEvent))
                return (TEntity)domainEvent.DynamicInvoke(obj, changes);
            else
                throw new ArgumentException($"DomainEvent: {eventName} is not registered.");

        }
    }
}
