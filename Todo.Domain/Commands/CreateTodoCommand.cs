using Flunt.Notifications;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }
        public CreateTodoCommand(string titulo, string usuario, DateTime data)
        {
            Titulo = titulo;
            Usuario = usuario;
            Data = data;
        }

        public string Titulo { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }

        public void Validate()
        {
            
        }
    }
}
