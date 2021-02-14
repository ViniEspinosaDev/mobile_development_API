using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.Usuario).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Titulo).HasMaxLength(160);
            modelBuilder.Entity<TodoItem>().Property(x => x.Concluida).HasMaxLength(1);
            modelBuilder.Entity<TodoItem>().Property(x => x.Data);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.Usuario);
        }
    }
}
