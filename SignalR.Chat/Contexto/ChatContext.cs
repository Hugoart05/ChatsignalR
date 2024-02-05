using Microsoft.EntityFrameworkCore;
using SignalR.Chat.Models;

namespace SignalR.Chat.Contexto
{
    public class ChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=prosafe;Integrated Security=True; TrustServerCertificate=True");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Mensagem> Mensagem { get; set;}

    }
}
