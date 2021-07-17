using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using health_system_api.Models;

namespace health_system_api.Models
{
    public class Context:DbContext
    {
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Doenca> Doencas { get; set; }
        public DbSet<Medida> Ingestoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Remedio> Remedios { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Consulta>(b =>
            {
                b.ToTable("Consulta");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Diagnostico>(b =>
            {
                b.ToTable("Diagnostico");

                b.HasKey(x => new { x.DoencaId, x.ConsultaId });
            });

            builder.Entity<Doenca>(b =>
            {
                b.ToTable("Doenca");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Medida>(b =>
            {
                b.ToTable("Ingestao");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Usuario>(b =>
            {
                b.ToTable("Usuario");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Paciente>(b =>
            {
                b.ToTable("Paciente");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Remedio>(b =>
            {
                b.ToTable("Remedio");

                b.HasKey(x => x.Id);
            });

            builder.Entity<Tratamento>(b =>
            {
                b.ToTable("Tratamento");

                b.HasKey(x => x.Id);
            });
        }
        public DbSet<health_system_api.Models.Autorizacao> Autorizacao { get; set; }

}
}
