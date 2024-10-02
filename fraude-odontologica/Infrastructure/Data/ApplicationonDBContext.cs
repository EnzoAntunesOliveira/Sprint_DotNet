using Microsoft.EntityFrameworkCore;
using FraudeOdontologica.Domain.Entities;

namespace FraudeOdontologica.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<AlertaFraude> AlertasFraude { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais podem ser feitas aqui, se necessário.
        }
    }
    
}