using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.TodoHandlers.Query.GetTodosQuery
{
    public class GetTodosQuery : IGetTodosQuery
    {
        private IDatabaseService _context;
        public GetTodosQuery(IDatabaseService context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> Handle(GetTodosQueryModel request, CancellationToken cancellationToken)
        {
            return await _context.Todos.FindAllAsync(i => i.TodoListId == request.TodoListId);
        }
    }
}
