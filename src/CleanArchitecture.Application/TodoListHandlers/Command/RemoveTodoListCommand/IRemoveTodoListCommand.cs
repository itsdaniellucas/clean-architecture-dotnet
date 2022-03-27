using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.TodoListHandlers.Command.RemoveTodoListCommand
{
    public interface IRemoveTodoListCommand : IRequestHandler<RemoveTodoListCommandModel>
    {
    }
}
