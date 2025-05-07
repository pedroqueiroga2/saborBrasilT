using Microsoft.EntityFrameworkCore;
using SaborBrasil.Models; // Certifique-se de importar o namespace correto

namespace SaborBrasil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura explicitamente o nome da tabela como "Usuario"
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}

