using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoListHandlers.Command.AddTodoListCommand
{
    public interface IAddTodoListCommand : IRequestHandler<AddTodoListCommandModel>
    {
    }
}
