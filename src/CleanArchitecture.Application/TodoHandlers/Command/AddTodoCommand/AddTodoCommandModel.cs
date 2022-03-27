using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoHandlers.Command.AddTodoCommand
{
    public class AddTodoCommandModel : IRequest
    {
        public string Title { get; set; }
        public Guid TodoListId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
