using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.AddTodoList
{
    public class AddTodoListDomainEvent : IDomainEvent<TodoList, AddTodoListChanges>, IDomainEvent
    {
        public static string Name
        {
            get { return nameof(AddTodoListDomainEvent); }
        }

        public TodoList Apply(TodoList model, AddTodoListChanges changes)
        {
            model.Id = changes.Id;
            model.Title = changes.Title;
            model.TodoIds = changes.TodoIds;
            model.UserId = changes.CreatedBy;
            model.CreatedBy = changes.CreatedBy;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateCreated = changes.DateCreated;
            model.DateModified = changes.DateModified;
            model.IsActive = changes.IsActive;
            return model;
        }
    }
}
