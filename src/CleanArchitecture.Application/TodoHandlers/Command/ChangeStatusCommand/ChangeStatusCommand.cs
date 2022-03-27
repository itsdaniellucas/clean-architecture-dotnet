using CleanArchitecture.Domain.Event.ChangeTodoStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.TodoHandlers.Command.ChangeStatusCommand
{
    public class ChangeStatusCommand : IChangeStatusCommand
    {
        public IEventStore _store;
        public ChangeStatusCommand(IEventStore store)
        {
            _store = store;
        }

        public async Task<Unit> Handle(ChangeStatusCommandModel request, CancellationToken cancellationToken)
        {
            var changes = request.Adapt<ChangeTodoStatusChanges>();
            changes.DateModified = DateTime.Now;
            await _store.Emit<Todo, ChangeTodoStatusChanges>(request.Id, ChangeTodoStatusDomainEvent.Name, changes);
            return await Task.FromResult(Unit.Value);
        }
    }
}
