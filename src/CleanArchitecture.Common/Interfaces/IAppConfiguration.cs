using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Common.Interfaces
{
    public interface IAppConfiguration
    {
        string ReadDBConnection { get; }
        string EventStoreConnection { get; }
        string DefaultServerConnection { get; }
        DbContextOptions GetDbContextOptions();
    }
}
