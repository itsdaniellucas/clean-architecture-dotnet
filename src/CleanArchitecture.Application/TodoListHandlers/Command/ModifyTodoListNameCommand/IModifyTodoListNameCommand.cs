using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoListHandlers.Command.ModifyTodoListNameCommand
{
    public interface IModifyTodoListNameCommand : IRequestHandler<ModifyTodoListNameCommandModel>
    {
    }
}
