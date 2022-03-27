using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class TodoRepository : Repository<Todo>
    {
    }
}
