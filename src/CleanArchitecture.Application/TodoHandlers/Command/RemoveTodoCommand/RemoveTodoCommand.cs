using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Event.RemoveTodo;
using MediatR;
using Mapster;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Event.ChangeTodoArrayInTodoList;

namespace CleanArchitecture.Application.TodoHandlers.Command.RemoveTodoCommand
{
    public class RemoveTodoCommand : IRemoveTodoCommand
    {
        IEventStore _store;
        IMediator _mediator;
        public RemoveTodoCommand(IEventStore store, IMediator mediator)
        {
            _store = store;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(RemoveTodoCommandModel request, CancellationToken cancellationToken)
        {
            var changes = request.Adapt<RemoveTodoChanges>();
            changes.DateModified = DateTime.Now;
            await _store.Emit<Todo, RemoveTodoChanges>(request.Id, RemoveTodoDomainEvent.Name, changes);

            if(!request.DeleteAll)
            {
                var todoList = _store.Load<TodoList>(request.TodoListId);
                todoList.TodoIds.Remove(request.Id);
                var eventChanges = new ChangeTodoArrayInTodoListChanges()
                {
                    TodoIds = todoList.TodoIds,
                    ModifiedBy = request.ModifiedBy,
                    DateModified = DateTime.Now,
                };
                await _store.Emit<TodoList, ChangeTodoArrayInTodoListChanges>(request.TodoListId, ChangeTodoArrayInTodoListDomainEvent.Name, eventChanges);
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}
