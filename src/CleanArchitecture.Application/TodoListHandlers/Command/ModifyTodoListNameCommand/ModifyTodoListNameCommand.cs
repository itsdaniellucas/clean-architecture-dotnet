using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Event.ModifyTodoListName;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.TodoListHandlers.Command.ModifyTodoListNameCommand
{
    public class ModifyTodoListNameCommand : IModifyTodoListNameCommand
    {
        IEventStore _store;
        public ModifyTodoListNameCommand(IEventStore store)
        {
            _store = store;
        }
        public async Task<Unit> Handle(ModifyTodoListNameCommandModel request, CancellationToken cancellationToken)
        {
            var changes = request.Adapt<ModifyTodoListNameChanges>();
            changes.DateModified = DateTime.Now;
            await _store.Emit<TodoList, ModifyTodoListNameChanges>(request.Id, ModifyTodoListNameDomainEvent.Name, changes);
            return await Task.FromResult(Unit.Value);
        }
    }
}
