using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoListHandlers.Command.AddTodoListCommand
{
    public class AddTodoListCommandModel : IRequest
    {
        public string Title { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
