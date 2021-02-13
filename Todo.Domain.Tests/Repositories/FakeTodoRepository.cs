using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Atualizar(TodoItem todo)
        {

        }

        public void Criar(TodoItem todo)
        {

        }

        public TodoItem GetById(Guid id, string usuario)
        {
            return new TodoItem("Titulo", DateTime.Now, "Usuario");
        }
    }
}
