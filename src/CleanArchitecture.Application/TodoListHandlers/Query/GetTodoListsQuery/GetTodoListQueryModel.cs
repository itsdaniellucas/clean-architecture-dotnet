using CleanArchitecture.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoListHandlers.Query.GetTodoListsQuery
{
    public class GetTodoListQueryModel : IRequest<IEnumerable<TodoList>>
    {
        public Guid UserId { get; set; }
    }
}
