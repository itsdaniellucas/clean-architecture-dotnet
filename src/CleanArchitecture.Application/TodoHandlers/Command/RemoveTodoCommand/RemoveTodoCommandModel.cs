using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.TodoHandlers.Command.RemoveTodoCommand
{
    public class RemoveTodoCommandModel : IRequest
    {
        public bool DeleteAll { get; set; }
        public Guid Id { get; set; }
        public Guid TodoListId { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
