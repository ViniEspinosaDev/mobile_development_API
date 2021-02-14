using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        #region Get
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetAll(usuario);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetAllDone(usuario);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetAllUndone(usuario);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetByPeriod(usuario, DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetByPeriod(usuario, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetByPeriod(usuario, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            string usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString();
            return repository.GetByPeriod(usuario, DateTime.Now.Date.AddDays(1), false);
        }
        #endregion

        [Route("")]
        [HttpPost]
        public GenericCommandResult Criar(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString(); ;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Atualizar(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString(); ;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString(); ;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value.ToString(); ;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
