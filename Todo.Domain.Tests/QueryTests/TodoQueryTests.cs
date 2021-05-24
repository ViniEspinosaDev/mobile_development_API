using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa1", DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa2", DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa3", DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa4", DateTime.Now, "Usuario3"));
            _items.Add(new TodoItem("Tarefa5", DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa6", DateTime.Now, "Usuario2"));
        }

        [TestMethod]
        public void DeveRetornarTarefasApenasDoUsuarioInformado()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Usuario1"));
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void DeveRetornarTarefasApenasDoUsuarioInformadoQueEstejamConcluidas()
        {
            _items.FirstOrDefault().MarcarComoConcluido();
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("Usuario1"));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DeveRetornarTarefasApenasDoUsuarioInformadoQueEstejamIncompletas()
        {
            _items.FirstOrDefault().MarcarComoConcluido();
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("Usuario1"));
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void DeveRetornarTarefasApenasDoUsuarioInformadoPeloPeriodo()
        {
            _items.FirstOrDefault().MarcarComoConcluido();
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("Usuario1", DateTime.Now, true));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DeveRetornarTarefasApenasDoUsuarioInformadoPeloId()
        {
            var usuario = _items.FirstOrDefault();

            var result = _items.AsQueryable().Where(TodoQueries.GetById(usuario.Id, usuario.User));
            Assert.AreEqual(1, result.Count());
        }
    }
}
