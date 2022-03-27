using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.TodoHandlers.Command.RemoveTodoCommand
{
    public interface IRemoveTodoCommand : IRequestHandler<RemoveTodoCommandModel>
    {
    }
}
