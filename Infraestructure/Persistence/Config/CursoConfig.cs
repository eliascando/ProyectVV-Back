using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class CursoConfig : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos");

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Parallel).IsRequired();
            builder.Property(c => c.CycleId).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Hours).IsRequired();

            builder.HasKey(c => c.Id);
        }
    }
}
