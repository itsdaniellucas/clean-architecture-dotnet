using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoListHandlers.Query.GetTodoListsQuery
{
    public class GetTodoListQuery : IGetTodoListQuery
    {
        IDatabaseService _context;
        public GetTodoListQuery(IDatabaseService context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TodoList>> Handle(GetTodoListQueryModel request, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.FindAllAsync(i => i.UserId == request.UserId);
        }
    }
}
