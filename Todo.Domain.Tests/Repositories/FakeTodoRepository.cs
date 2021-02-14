using System;
using System.Collections.Generic;
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

        public IEnumerable<TodoItem> GetAll(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string usuario)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string usuario)
        {
            return new TodoItem("Titulo", DateTime.Now, "Usuario");
        }

        public IEnumerable<TodoItem> GetByPeriod(string usuario, DateTime data, bool concluida)
        {
            throw new NotImplementedException();
        }
    }
}
