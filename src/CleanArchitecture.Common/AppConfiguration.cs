using CleanArchitecture.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Common
{
    public class AppConfiguration : IAppConfiguration
    {
        public const string EventStore = "EventStore";
        public string ReadDBConnection { get; private set; }
        public string EventStoreConnection { get; private set; }
        public string DefaultServerConnection { get; private set; }

        public AppConfiguration()
        {
            var config = new ConfigurationBuilder().AddJsonFile(Constants.AppSettings).Build();
            ReadDBConnection = config[$"{Constants.ConnectionStrings}:{Constants.ReadDB}"];
            EventStoreConnection = config[$"{Constants.ConnectionStrings}:{Constants.EventStore}"];
            DefaultServerConnection = config[$"{Constants.ConnectionStrings}:{Constants.DefaultServer}"];
        }

        public DbContextOptions GetDbContextOptions()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(ReadDBConnection);
            return options.Options;
        }
    }
}
