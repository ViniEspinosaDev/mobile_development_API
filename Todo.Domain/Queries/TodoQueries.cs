using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string usuario)
        {
            return x => x.User == usuario;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string usuario)
        {
            return x => x.User == usuario && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string usuario)
        {
            return x => x.User == usuario && !x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string usuario, DateTime data, bool concluida)
        {
            return x => x.User == usuario &&
                        x.Done == concluida &&
                        x.Date.Date == data.Date;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id, string usuario)
        {
            return x => x.Id == id &&
                        x.User == usuario;
        }
    }
}
