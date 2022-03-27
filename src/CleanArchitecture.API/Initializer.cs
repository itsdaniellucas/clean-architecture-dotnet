using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Common;
using CleanArchitecture.Common.Helper;
using CleanArchitecture.Common.Interfaces;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Event.AddTodo;
using CleanArchitecture.Domain.Event.AddTodoList;
using CleanArchitecture.Domain.Event.ChangeTodoArrayInTodoList;
using CleanArchitecture.Domain.Event.ChangeTodoStatus;
using CleanArchitecture.Domain.Event.ModifyTodoListName;
using CleanArchitecture.Domain.Event.RemoveTodo;
using CleanArchitecture.Domain.Event.RemoveTodoList;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.EventSourcing;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using NEventStore.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.API
{
    public static class Initializer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            // config
            services.AddSingleton<IAppConfiguration, AppConfiguration>();

            // DbContext
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IDatabaseService, DatabaseService>();

            // Event Store
            services.AddScoped<IEventStore, EventStore>();
            services.AddSingleton<IStoreEvents>(provider =>
            {
                var config = provider.GetService<IAppConfiguration>();

                SQLHelper.CreateDBIfNotExists(config.DefaultServerConnection, Constants.CleanArchitectureEventStore);

                return Wireup.Init()
                            .UsingSqlPersistence(SqlClientFactory.Instance, config.EventStoreConnection)
                            .WithDialect(new MsSqlDialect())
                            .InitializeStorageEngine()
                            .UsingJsonSerialization()
                            .Compress()
                            .Build();
            });
        }

        public static void RegisterDomainEvents()
        {
            DomainEventStore.Register<Todo, AddTodoChanges>(AddTodoDomainEvent.Name, new AddTodoDomainEvent().Apply);
            DomainEventStore.Register<Todo, ChangeTodoStatusChanges>(ChangeTodoStatusDomainEvent.Name, new ChangeTodoStatusDomainEvent().Apply);
            DomainEventStore.Register<Todo, RemoveTodoChanges>(RemoveTodoDomainEvent.Name, new RemoveTodoDomainEvent().Apply);
            DomainEventStore.Register<TodoList, ChangeTodoArrayInTodoListChanges>(ChangeTodoArrayInTodoListDomainEvent.Name, new ChangeTodoArrayInTodoListDomainEvent().Apply);
            DomainEventStore.Register<TodoList, AddTodoListChanges>(AddTodoListDomainEvent.Name, new AddTodoListDomainEvent().Apply);
            DomainEventStore.Register<TodoList, ModifyTodoListNameChanges>(ModifyTodoListNameDomainEvent.Name, new ModifyTodoListNameDomainEvent().Apply);
            DomainEventStore.Register<TodoList, RemoveTodoListChanges>(RemoveTodoListDomainEvent.Name, new RemoveTodoListDomainEvent().Apply);
        }

        public static void ConstructDatabase(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var scopeFactory = serviceProvider.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = (scope.ServiceProvider.GetRequiredService<IDatabaseContext>() as DbContext);
                context.Database.EnsureCreated();
            }
        }
    }
}
