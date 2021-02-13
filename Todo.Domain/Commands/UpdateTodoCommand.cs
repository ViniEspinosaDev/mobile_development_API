using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string titulo, string usuario)
        {
            Id = id;
            Titulo = titulo;
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Usuario { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Titulo, 3, nameof(Titulo), "Titulo precisa conter mais que 3 caracteres.")
                .HasMinLen(Usuario, 2, nameof(Usuario), "Usuário deve ter mais que 2 caracteres."));
        }
    }
}
