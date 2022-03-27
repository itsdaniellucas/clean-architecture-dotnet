using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IDomainEntity
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        Guid CreatedBy { get; set; }
        Guid ModifiedBy { get; set; }
        bool IsActive { get; set; }
    }
}
