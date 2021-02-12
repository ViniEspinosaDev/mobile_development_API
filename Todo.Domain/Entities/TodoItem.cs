using System;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string titulo, DateTime data, string usuario)
        {
            Titulo = titulo;
            Concluida = false;
            Data = data;
            Usuario = usuario;
        }

        public string Titulo { get; private set; }
        public bool Concluida { get; private set; }
        public DateTime Data { get; private set; }
        public string Usuario { get; private set; }

        public void Concluir() =>
            Concluida = true;

        public void Desconcluir() =>
            Concluida = false;

        public void AtualizarTitulo(string titulo) =>
            Titulo = titulo;
    }
}
