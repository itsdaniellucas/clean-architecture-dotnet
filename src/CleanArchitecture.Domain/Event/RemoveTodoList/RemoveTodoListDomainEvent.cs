using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Event.RemoveTodoList
{
    public class RemoveTodoListDomainEvent : IDomainEvent<TodoList, RemoveTodoListChanges>
    {
        public static string Name
        {
            get { return nameof(RemoveTodoListDomainEvent); }
        }

        public TodoList Apply(TodoList model, RemoveTodoListChanges changes)
        {
            model.TodoIds = changes.TodoIds;
            model.IsActive = changes.IsActive;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateModified = changes.DateModified;
            return model;
        }
    }
}
