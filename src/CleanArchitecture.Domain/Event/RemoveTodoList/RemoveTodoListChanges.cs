using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Event.RemoveTodoList
{
    public class RemoveTodoListChanges : IDomainEventChanges
    {
        public List<Guid> TodoIds { get; } = new List<Guid>();
        public bool IsActive { get; } = false;
        public Guid ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
