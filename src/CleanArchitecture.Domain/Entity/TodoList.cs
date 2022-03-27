using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entity
{
    public class TodoList : IDomainEntity
    {
        public string Title { get; set; }
        public List<Guid> TodoIds { get; set; } = new List<Guid>();
        public ICollection<Todo> Todos { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
