using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Event.ChangeTodoArrayInTodoList
{
    public class ChangeTodoArrayInTodoListDomainEvent : IDomainEvent<TodoList, ChangeTodoArrayInTodoListChanges>
    {
        public static string Name
        {
            get { return nameof(ChangeTodoArrayInTodoListDomainEvent); }
        }
        public TodoList Apply(TodoList model, ChangeTodoArrayInTodoListChanges changes)
        {
            model.TodoIds = changes.TodoIds;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateModified = changes.DateModified;
            return model;
        }
    }
}
