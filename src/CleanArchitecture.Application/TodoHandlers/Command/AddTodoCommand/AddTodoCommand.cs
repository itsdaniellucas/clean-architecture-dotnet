using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Event.AddTodo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Event.ChangeTodoArrayInTodoList;

namespace CleanArchitecture.Application.TodoHandlers.Command.AddTodoCommand
{
    public class AddTodoCommand : IAddTodoCommand
    {
        IEventStore _store;

        public AddTodoCommand(IEventStore store)
        {
            _store = store;
        }

        public async Task<Unit> Handle(AddTodoCommandModel request, CancellationToken cancellationToken)
        {
            var changes = request.Adapt<AddTodoChanges>();
            changes.Id = Guid.NewGuid();
            await _store.Emit<Todo, AddTodoChanges>(changes.Id, AddTodoDomainEvent.Name, changes);

            var todoList = _store.Load<TodoList>(request.TodoListId);
            var todoListChanges = todoList.Adapt<ChangeTodoArrayInTodoListChanges>();
            todoListChanges.TodoIds.Add(changes.Id);
            todoListChanges.ModifiedBy = request.CreatedBy;
            await _store.Emit<TodoList, ChangeTodoArrayInTodoListChanges>(request.TodoListId, ChangeTodoArrayInTodoListDomainEvent.Name, todoListChanges);

            return await Task.FromResult(Unit.Value);
        }
    }
}
