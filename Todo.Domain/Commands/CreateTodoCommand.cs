﻿using Flunt.Notifications;
using Flunt.Validations;
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
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Titulo, 3, nameof(Titulo), "Titulo precisa conter mais que 3 caracteres.")
                .HasMinLen(Usuario, 2, nameof(Usuario), "Usuário deve ter mais que 2 caracteres."));
        }
    }
}