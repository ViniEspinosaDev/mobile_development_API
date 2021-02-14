using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Criar(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.Usuario = "Usuario1";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("Usuario1");
        }
    }
}
