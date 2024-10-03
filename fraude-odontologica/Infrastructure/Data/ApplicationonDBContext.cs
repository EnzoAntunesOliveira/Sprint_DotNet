using Microsoft.EntityFrameworkCore;
using FraudeOdontologica.Domain.Entities;
namespace FraudeOdontologica.Infrastructure.Data;

    
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.Id); 
            
            modelBuilder.Entity<Dentista>()
                .HasKey(d => d.Id);
            
            modelBuilder.Entity<Consulta>()
                .HasKey(c => c.Id); 

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente) 
                .WithMany(p => p.Consultas) 
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Dentista) 
                .WithMany(d => d.Consultas) 
                .HasForeignKey(c => c.DentistaId)
                .OnDelete(DeleteBehavior.Cascade); 
            
            modelBuilder.Entity<Tratamento>()
                .HasKey(t => t.Id); 

            modelBuilder.Entity<Tratamento>()
                .HasOne(t => t.Consulta) 
                .WithMany(c => c.Tratamentos) 
                .HasForeignKey(t => t.ConsultaId) 
                .OnDelete(DeleteBehavior.Cascade); 
        }

    }

    
