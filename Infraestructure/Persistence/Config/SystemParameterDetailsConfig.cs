using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class SystemParameterDetailsConfig : IEntityTypeConfiguration<SystemParameterDetails>
    {
        public void Configure(EntityTypeBuilder<SystemParameterDetails> builder)
        {
            builder.ToTable("SystemParameterDetails");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.SystemParameterId).IsRequired();
            builder.Property(e => e.Value).IsRequired();

            builder.HasOne(d => d.SystemParameter)
                .WithMany(p => p.Details)
                .HasForeignKey(d => d.SystemParameterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SystemParameterDetails { Id = 1, Description = "Docente", SystemParameterId = 1, Value = "DOC" },
                new SystemParameterDetails { Id = 2, Description = "Estudiante", SystemParameterId = 1, Value = "EST" },
                new SystemParameterDetails { Id = 3, Description = "Secretaria", SystemParameterId = 1, Value = "SEC" },
                new SystemParameterDetails { Id = 4, Description = "Administrador", SystemParameterId = 1, Value = "ADM" },
                new SystemParameterDetails { Id = 5, Description = "CICLO I - 2023", SystemParameterId = 2, Value = "CI2023" },
                new SystemParameterDetails { Id = 6, Description = "CICLO II - 2023", SystemParameterId = 2, Value = "CII2023" },
                new SystemParameterDetails { Id = 7, Description = "CICLO I - 2024", SystemParameterId = 2, Value = "CI2024" },
                new SystemParameterDetails { Id = 8, Description = "CICLO II - 2024", SystemParameterId = 2, Value = "CII2024" },
                new SystemParameterDetails { Id = 9, Description = "DOCENTE", SystemParameterId = 3, Value = "MAT-DOC" },
                new SystemParameterDetails { Id = 10, Description = "ESTUDIANTE", SystemParameterId = 3, Value = "MAT-EST" },
                new SystemParameterDetails { Id = 11, Description = "PORC_FORMATIVA", SystemParameterId = 4, Value = "0.33"},
                new SystemParameterDetails { Id = 12, Description = "PORC_PRACTICA", SystemParameterId = 4, Value = "0.33" },
                new SystemParameterDetails { Id = 13, Description = "PORC_ACREDITACION", SystemParameterId = 4, Value = "0.33" },
                new SystemParameterDetails { Id = 14, Description = "FORMATIVA", SystemParameterId = 5, Value = "T_FORM" },
                new SystemParameterDetails { Id = 15, Description = "PRACTICA", SystemParameterId = 5, Value = "T_PRCT" },
                new SystemParameterDetails { Id = 16, Description = "ACREDITACION", SystemParameterId = 5, Value = "T_ACRE" },
                new SystemParameterDetails { Id = 17, Description = "PROMEDIO", SystemParameterId = 5, Value = "T_TTL" },
                new SystemParameterDetails { Id = 18, Description = "PRIMER PARCIAL", SystemParameterId = 6, Value = "1PARC" },
                new SystemParameterDetails { Id = 19, Description = "SEGUNDO PARCIAL", SystemParameterId = 6, Value = "2PARC" },
                new SystemParameterDetails { Id = 20, Description = "PROMEDIO FINAL", SystemParameterId = 6, Value = "0TOT" }
            );
        }
    }
}
