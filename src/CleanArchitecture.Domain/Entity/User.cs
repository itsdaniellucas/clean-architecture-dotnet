using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;


namespace CleanArchitecture.Domain.Entity
{
    public class User : IDomainEntity
    {
        public string Username { get; set; }
        public ICollection<TodoList> TodoLists { get; set; }
        public List<Guid> TodoListIds { get; set; } = new List<Guid>();

        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
