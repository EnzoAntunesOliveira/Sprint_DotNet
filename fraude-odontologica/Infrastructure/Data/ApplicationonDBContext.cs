using fraude_odontologica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fraude_odontologica.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("CH_PACIENTES"); // Nome da tabela no banco de dados
                entity.HasKey(p => p.IdPaciente); // Defina a chave primária
                entity.Property(p => p.IdPaciente).HasColumnName("ID_PACIENTE"); // Nome da coluna no banco de dados
                entity.Property(p => p.Nome).IsRequired().HasColumnName("NOME").HasColumnType("VARCHAR2(30)");
                entity.Property(p => p.CPF).IsRequired();
                entity.Property(p => p.DataNascimento).IsRequired().HasColumnName("DATA_NASCIMENTO").HasColumnType("DATE");
                entity.Property(p => p.PlanoSaude).IsRequired().HasColumnName("PLANO_SAUDE").HasColumnType("VARCHAR2(50)");
                entity.Property(p => p.Telefone).IsRequired().HasColumnName("TELEFONE").HasColumnType("VARCHAR2(20)");
                entity.Property(p => p.Email).IsRequired().HasColumnName("EMAIL").HasColumnType("VARCHAR2(50)");
            });

            modelBuilder.Entity<Dentista>(entity =>
            {
                entity.ToTable("CH_DENTISTAS");
                entity.HasKey(d => d.IdDentista);
                entity.Property(d => d.IdDentista).HasColumnName("ID_DENTISTA");
                entity.Property(d => d.Nome).IsRequired().HasColumnName("NOME_DENTISTA").HasColumnType("VARCHAR2(50)");
                entity.Property(d => d.CRO).IsRequired();
                entity.Property(d => d.Especialidade).IsRequired().HasColumnName("ESPECIALIDADE").HasColumnType("VARCHAR2(30)");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.ToTable("CH_CONSULTAS");
                entity.HasKey(c => c.IdConsulta);
                entity.Property(c => c.IdConsulta).HasColumnName("ID_CONSULTA");
                entity.Property(c => c.DataConsulta).IsRequired().HasColumnName("DATA_CONSULTA").HasColumnType("DATE");
                entity.Property(c => c.CustoConsulta).IsRequired().HasColumnName("CUSTO_CONSULTA").HasColumnType("NUMBER(10,2)");
                entity.Property(c => c.TipoTratamento).IsRequired().HasColumnName("TIPO_TRATAMENTO").HasColumnType("VARCHAR2(50)");

                // Configuração do relacionamento
                entity.HasOne(c => c.Paciente)
                    .WithMany() // Se você não deseja manter uma coleção de consultas no paciente
                    .HasForeignKey("ID_PACIENTE") // Nome da coluna no banco de dados
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Dentista)
                    .WithMany() // Se você não deseja manter uma coleção de consultas no dentista
                    .HasForeignKey("ID_DENTISTA") // Nome da coluna no banco de dados
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
