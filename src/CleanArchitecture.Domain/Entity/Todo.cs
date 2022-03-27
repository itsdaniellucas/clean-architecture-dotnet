using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entity
{
    public class Todo : IDomainEntity
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public Guid TodoListId { get; set; }
        public TodoList TodoList { get; set; }


        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
