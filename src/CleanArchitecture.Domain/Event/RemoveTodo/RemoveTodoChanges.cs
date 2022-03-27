using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Event.RemoveTodo
{
    public class RemoveTodoChanges : IDomainEventChanges
    {
        public bool IsActive { get; } = false;
        public DateTime DateModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
