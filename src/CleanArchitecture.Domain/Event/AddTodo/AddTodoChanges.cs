using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.AddTodo
{
    public class AddTodoChanges : IDomainEventChanges
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid TodoListId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; } = Guid.Empty;
        public DateTime DateCreated { get; } = DateTime.Now;
        public DateTime DateModified { get; } = DateTime.Now;
        public bool IsActive { get; } = true;
        public bool IsDone { get; } = false;
    }
}
