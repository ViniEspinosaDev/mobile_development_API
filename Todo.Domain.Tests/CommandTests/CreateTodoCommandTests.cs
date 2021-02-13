using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "Usuario", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void DadoUmComandoInvalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void DadoUmComandoValido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}