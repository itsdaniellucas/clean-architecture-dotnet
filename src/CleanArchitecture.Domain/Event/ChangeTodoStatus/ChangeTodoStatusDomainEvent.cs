using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Event.ChangeTodoStatus
{
    public class ChangeTodoStatusDomainEvent : IDomainEvent<Todo, ChangeTodoStatusChanges>
    {
        public static string Name
        {
            get { return nameof(ChangeTodoStatusDomainEvent); }
        }
        public Todo Apply(Todo model, ChangeTodoStatusChanges changes)
        {
            model.IsDone = changes.IsDone;
            model.ModifiedBy = changes.ModifiedBy;
            model.DateModified = changes.DateModified;
            return model;
        }
    }
}
