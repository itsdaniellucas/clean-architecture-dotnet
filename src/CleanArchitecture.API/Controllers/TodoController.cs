using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Application.TodoHandlers.Command.AddTodoCommand;
using CleanArchitecture.Application.TodoHandlers.Command.ChangeStatusCommand;
using CleanArchitecture.Application.TodoHandlers.Command.RemoveTodoCommand;
using CleanArchitecture.Application.TodoHandlers.Query.GetTodosQuery;
using CleanArchitecture.Application.TodoListHandlers.Command.AddTodoListCommand;
using CleanArchitecture.Application.TodoListHandlers.Command.ModifyTodoListNameCommand;
using CleanArchitecture.Application.TodoListHandlers.Command.RemoveTodoListCommand;
using CleanArchitecture.Application.TodoListHandlers.Query.GetTodoListsQuery;
using CleanArchitecture.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        Guid userId = new Guid("cec6504b-ce22-49f9-b493-80a47556e0ba");
        IMediator _mediator;
        IStoreEvents _store;

        public TodoController(IMediator mediator, IStoreEvents store)
        {
            _mediator = mediator;
            _store = store;
        }

        [HttpGet]
        [Route("list/{todoListId}/todo")]
        public async Task<IActionResult> GetTodos([FromRoute]Guid todoListId)
        {
            var result = await _mediator.Send(new GetTodosQueryModel()
            {
                TodoListId = todoListId
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetTodoLists()
        {
            var result = await _mediator.Send(new GetTodoListQueryModel()
            {
                UserId = userId
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("list/{todoListId}/todo")]
        public async Task<IActionResult> CreateTodo([FromRoute] Guid todoListId, [FromBody]AddTodoCommandModel model)
        {
            model.TodoListId = todoListId;
            model.CreatedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpPost]
        [Route("list/{todoListId}/todo/{todoId}/remove")]
        public async Task<IActionResult> RemoveTodo([FromRoute] Guid todoListId, [FromRoute] Guid todoId, [FromBody] RemoveTodoCommandModel model)
        {
            model.Id = todoId;
            model.TodoListId = todoListId;
            model.ModifiedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpPost]
        [Route("list/{todoListId}/todo/{todoId}")]
        public async Task<IActionResult> ChangeTodoStatus([FromRoute] Guid todoListId, [FromRoute] Guid todoId, [FromBody] ChangeStatusCommandModel model)
        {
            model.Id = todoId;
            model.ModifiedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> CreateTodoList([FromBody] AddTodoListCommandModel model)
        {
            model.CreatedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpPost]
        [Route("list/{todoListId}/rename")]
        public async Task<IActionResult> RenameTodoList([FromRoute] Guid todoListId, [FromBody] ModifyTodoListNameCommandModel model)
        {
            model.Id = todoListId;
            model.ModifiedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpPost]
        [Route("list/{todoListId}/remove")]
        public async Task<IActionResult> RemoveTodoList([FromRoute] Guid todoListId, [FromBody] RemoveTodoListCommandModel model)
        {
            model.Id = todoListId;
            model.ModifiedBy = userId;
            var result = await _mediator.Send(model);
            return Ok();
        }

        [HttpGet]
        [Route("logs/{id}")]
        public async Task<IActionResult> GetEventStoreLogs([FromRoute] Guid id)
        {
            using (var stream = _store.OpenStream(id, 0, int.MaxValue))
            {
                var result = await Task.FromResult(stream.CommittedEvents);
                return Ok(result);
            }
        }
    }
}
