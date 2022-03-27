using CleanArchitecture.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Event.RemoveTodoList;
using CleanArchitecture.Application.TodoHandlers.Command.RemoveTodoCommand;

namespace CleanArchitecture.Application.TodoListHandlers.Command.RemoveTodoListCommand
{
    public class RemoveTodoListCommand : IRemoveTodoListCommand
    {
        IEventStore _store;
        IMediator _mediator;
        public RemoveTodoListCommand(IEventStore store, IMediator mediator)
        {
            _store = store;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(RemoveTodoListCommandModel request, CancellationToken cancellationToken)
        {

            var todoList = _store.Load<TodoList>(request.Id);

            var changes = request.Adapt<RemoveTodoListChanges>();
            changes.DateModified = DateTime.Now;
            await _store.Emit<TodoList, RemoveTodoListChanges>(request.Id, RemoveTodoListDomainEvent.Name, changes);

            foreach(var id in todoList.TodoIds)
            {
                await _mediator.Send(new RemoveTodoCommandModel()
                {
                    Id = id,
                    ModifiedBy = request.ModifiedBy,
                    DeleteAll = true,
                });
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}
