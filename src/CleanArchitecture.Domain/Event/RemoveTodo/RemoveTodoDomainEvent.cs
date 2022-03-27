using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.RemoveTodo
{
    public class RemoveTodoDomainEvent : IDomainEvent<Todo, RemoveTodoChanges>
    {
        public static string Name
        {
            get { return nameof(RemoveTodoDomainEvent); }
        }
        public Todo Apply(Todo model, RemoveTodoChanges changes)
        {
            model.IsActive = changes.IsActive;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateModified = changes.DateModified;
            return model;
        }
    }
}
