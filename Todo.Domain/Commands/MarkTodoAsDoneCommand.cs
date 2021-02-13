using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand() { }
        public MarkTodoAsDoneCommand(Guid id, string usuario)
        {
            Id = id;
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public string Usuario { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Usuario, 2, nameof(Usuario), "Usuário deve ter mais que 2 caracteres."));
        }
    }
}
