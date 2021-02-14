using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Criar(TodoItem todo);
        void Atualizar(TodoItem todo);
        TodoItem GetById(Guid id, string usuario);
        IEnumerable<TodoItem> GetAll(string usuario);
        IEnumerable<TodoItem> GetAllDone(string usuario);
        IEnumerable<TodoItem> GetAllUndone(string usuario);
        IEnumerable<TodoItem> GetByPeriod(string usuario, DateTime data, bool concluida);
    }
}
