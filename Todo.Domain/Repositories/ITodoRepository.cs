using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Criar(TodoItem todo);
        void Atualizar(TodoItem todo);
        TodoItem GetById(Guid id, string usuario);
    }
}
