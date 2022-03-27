using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoHandlers.Command.AddTodoCommand
{
    public interface IAddTodoCommand : IRequestHandler<AddTodoCommandModel>
    {
    }
}
