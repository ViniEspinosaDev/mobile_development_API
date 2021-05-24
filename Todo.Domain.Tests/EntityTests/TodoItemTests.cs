using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodoItem = new TodoItem("Titulo", DateTime.Now, "Usuario");

        [TestMethod]
        public void DadoUmNovoTodoOMesmoNaoPodeSerConcluido()
        {
            Assert.AreEqual(_validTodoItem.Done, false);
        }
    }
}
