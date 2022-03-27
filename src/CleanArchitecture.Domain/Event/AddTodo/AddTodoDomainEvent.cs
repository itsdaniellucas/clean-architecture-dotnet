using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.AddTodo
{
    public class AddTodoDomainEvent : IDomainEvent<Todo, AddTodoChanges>
    {
        public static string Name
        {
            get { return nameof(AddTodoDomainEvent); }
        }

        public Todo Apply(Todo model, AddTodoChanges changes)
        {
            model.Id = changes.Id;
            model.Title = changes.Title;
            model.TodoListId = changes.TodoListId;
            model.CreatedBy = changes.CreatedBy;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateCreated = changes.DateCreated;
            model.DateModified = changes.DateModified;
            model.IsActive = changes.IsActive;
            model.IsDone = changes.IsDone;
            return model;
        }
    }
}
