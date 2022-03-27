using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Event.AddTodoList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Mapster;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.TodoListHandlers.Command.AddTodoListCommand
{
    public class AddTodoListCommand : IAddTodoListCommand
    {
        IEventStore _store;
        public AddTodoListCommand(IEventStore store)
        {
            _store = store;
        }

        public async Task<Unit> Handle(AddTodoListCommandModel request, CancellationToken cancellationToken)
        {
            var changes = request.Adapt<AddTodoListChanges>();
            changes.Id = Guid.NewGuid();
            await _store.Emit<TodoList, AddTodoListChanges>(changes.Id, AddTodoListDomainEvent.Name, changes);
            return await Task.FromResult(Unit.Value);
        }
    }
}
