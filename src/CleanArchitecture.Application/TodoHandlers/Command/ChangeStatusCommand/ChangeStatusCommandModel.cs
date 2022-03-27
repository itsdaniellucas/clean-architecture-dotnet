using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.TodoHandlers.Command.ChangeStatusCommand
{
    public class ChangeStatusCommandModel : IRequest
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
