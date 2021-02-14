using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Atualizar(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Criar(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string usuario)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(usuario)).OrderBy(x => x.Data);
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
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string usuario, DateTime data, bool concluida)
        {
            throw new NotImplementedException();
        }
    }
}