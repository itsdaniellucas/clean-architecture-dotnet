using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.ModifyTodoListName
{
    public class ModifyTodoListNameDomainEvent : IDomainEvent<TodoList, ModifyTodoListNameChanges>
    {
        public static string Name
        {
            get { return nameof(ModifyTodoListNameChanges); }
        }
        public TodoList Apply(TodoList model, ModifyTodoListNameChanges changes)
        {
            model.Title = changes.Title;
            model.DateModified = changes.DateModified;
            model.ModifiedBy = changes.ModifiedBy;
            return model;
        }
    }
}
