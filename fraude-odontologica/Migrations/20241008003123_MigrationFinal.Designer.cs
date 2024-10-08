﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using fraude_odontologica.Infrastructure.Data;

#nullable disable

namespace fraude_odontologica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241008003123_MigrationFinal")]
    partial class MigrationFinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fraude_odontologica.Domain.Entities.Consulta", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_CONSULTA");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"));

                    b.Property<decimal>("CustoConsulta")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("CUSTO_CONSULTA");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_CONSULTA");

                    b.Property<int>("DentistaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoTratamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdConsulta");

                    b.HasIndex("DentistaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("CH_CONSULTAS", (string)null);
                });

            modelBuilder.Entity("fraude_odontologica.Domain.Entities.Dentista", b =>
                {
                    b.Property<int>("IdDentista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_DENTISTA");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDentista"));

                    b.Property<string>("CRO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(30)")
                        .HasColumnName("ESPECIALIDADE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("NOME_DENTISTA");

                    b.HasKey("IdDentista");

                    b.ToTable("CH_DENTISTAS", (string)null);
                });

            modelBuilder.Entity("fraude_odontologica.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_PACIENTE");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(30)")
                        .HasColumnName("NOME");

                    b.Property<string>("PlanoSaude")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("PLANO_SAUDE");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR2(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("IdPaciente");

                    b.ToTable("CH_PACIENTES", (string)null);
                });

            modelBuilder.Entity("fraude_odontologica.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("fraude_odontologica.Domain.Entities.Dentista", "Dentista")
                        .WithMany()
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("fraude_odontologica.Domain.Entities.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
