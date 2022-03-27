using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using NEventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.EventSourcing
{
    public class EventStore : IEventStore
    {
        IStoreEvents _store;
        IDatabaseService _context;
        public EventStore(IStoreEvents store, IDatabaseService context)
        {
            _context = context;
            _store = store;
        }

        public async Task Emit<TEntity, TChanges>(Guid id, string eventName, TChanges changes)
            where TEntity : class, IDomainEntity
            where TChanges : class, IDomainEventChanges
        {
            // emit to event store
            using(var stream = _store.OpenStream(id, 0, int.MaxValue))
            {
                var domainEvent = new DomainEventMessage()
                {
                    EventData = changes,
                    EventName = eventName
                };

                stream.Add(new EventMessage()
                {
                    Body = domainEvent
                });

                stream.CommitChanges(Guid.NewGuid());
            }

            // apply changes to read db
            var repo = _context.Repo<TEntity>();
            if(repo != null)
            {
                var model = this.Load<TEntity>(id);
                var found = await repo.FindByIdAsync(id);
                if (found == null)
                    repo.Insert(model);
                else
                    repo.Update(model);
                    
                await _context.CommitAsync<TEntity>();
            }
        }

        public TEntity Load<TEntity>(Guid id, int from = 0) where TEntity : class, IDomainEntity
        {
            using (var stream = _store.OpenStream(id, from, int.MaxValue))
            {
                if (stream.CommittedEvents.Count == 0)
                    return null;

                var result = Activator.CreateInstance<TEntity>();
                foreach (var events in stream.CommittedEvents)
                {
                    var domainEvent = events.Body as DomainEventMessage;
                    result = DomainEventStore.Apply(domainEvent.EventName, result, domainEvent.EventData);
                }
                return result;
            }
        }
    }
}
