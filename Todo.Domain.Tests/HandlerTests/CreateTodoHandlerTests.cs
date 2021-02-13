using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "Usuario", DateTime.Now);
        private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void DadoUmComandoInvalidoDeveInterromperExecucao()
        {
            var result = (GenericCommandResult)_todoHandler.Handle(_invalidCommand);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveCriarTarefa()
        {
            var result = (GenericCommandResult)_todoHandler.Handle(_validCommand);
            Assert.AreEqual(result.Sucesso, true);
        }
    }
}
