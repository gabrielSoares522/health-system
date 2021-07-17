﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using health_system_api.Models;

namespace health_system_api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("health_system_api.Models.Autorizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autorizacao");
                });

            modelBuilder.Entity("health_system_api.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("diaConsulta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("health_system_api.Models.Diagnostico", b =>
                {
                    b.Property<int>("DoencaId")
                        .HasColumnType("int");

                    b.Property<int>("ConsultaId")
                        .HasColumnType("int");

                    b.HasKey("DoencaId", "ConsultaId");

                    b.HasIndex("ConsultaId");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("health_system_api.Models.Doenca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doenca");
                });

            modelBuilder.Entity("health_system_api.Models.Medida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingestao");
                });

            modelBuilder.Entity("health_system_api.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Genero")
                        .HasColumnType("bit");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("health_system_api.Models.Remedio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedidaId")
                        .HasColumnType("int");

                    b.Property<int>("Nome")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedidaId");

                    b.ToTable("Remedio");
                });

            modelBuilder.Entity("health_system_api.Models.Tratamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RemedioId")
                        .HasColumnType("int");

                    b.Property<int>("qtDiasDuracao")
                        .HasColumnType("int");

                    b.Property<int>("qtDose")
                        .HasColumnType("int");

                    b.Property<int>("qtHorasIntervalo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("RemedioId");

                    b.ToTable("Tratamento");
                });

            modelBuilder.Entity("health_system_api.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorizacaoId")
                        .HasColumnType("int");

                    b.Property<string>("CRM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorizacaoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("health_system_api.Models.Consulta", b =>
                {
                    b.HasOne("health_system_api.Models.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("health_system_api.Models.Usuario", "Usuario")
                        .WithMany("Consultas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("health_system_api.Models.Diagnostico", b =>
                {
                    b.HasOne("health_system_api.Models.Consulta", "Consulta")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("health_system_api.Models.Doenca", "Doenca")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("DoencaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("health_system_api.Models.Remedio", b =>
                {
                    b.HasOne("health_system_api.Models.Medida", "Medida")
                        .WithMany("Remedios")
                        .HasForeignKey("MedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("health_system_api.Models.Tratamento", b =>
                {
                    b.HasOne("health_system_api.Models.Consulta", "Consulta")
                        .WithMany("Tratamentos")
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("health_system_api.Models.Remedio", "Remedio")
                        .WithMany("Tratamentos")
                        .HasForeignKey("RemedioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("health_system_api.Models.Usuario", b =>
                {
                    b.HasOne("health_system_api.Models.Autorizacao", "Autorizacao")
                        .WithMany("Usuarios")
                        .HasForeignKey("AutorizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}