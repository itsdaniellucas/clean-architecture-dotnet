using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.ChangeTodoArrayInTodoList
{
    public class ChangeTodoArrayInTodoListChanges : IDomainEventChanges
    {
        public List<Guid> TodoIds { get; set; } = new List<Guid>();
        public Guid ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
