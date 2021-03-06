using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.TodoHandlers.Query.GetTodosQuery
{
    public interface IGetTodosQuery : IRequestHandler<GetTodosQueryModel, IEnumerable<Todo>>
    {
    }
}
