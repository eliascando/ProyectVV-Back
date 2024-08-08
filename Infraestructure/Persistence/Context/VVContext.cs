using Domain.Models;
using Infraestructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Context
{
    public class VVContext : DbContext
    {
        public VVContext(DbContextOptions<VVContext> options) : base(options) { }

        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<SystemParameterDetails> SystemParametersDetails { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new SystemParameterConfig());
            modelBuilder.ApplyConfiguration(new SystemParameterDetailsConfig());
            modelBuilder.ApplyConfiguration(new CursoConfig());
        }
    }
}
