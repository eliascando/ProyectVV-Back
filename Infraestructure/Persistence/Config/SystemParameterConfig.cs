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
    public class SystemParameterConfig : IEntityTypeConfiguration<SystemParameter>
    {
        public void Configure(EntityTypeBuilder<SystemParameter> builder)
        {
            builder.ToTable("SystemParameters");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasMany(e => e.Details)
                .WithOne(d => d.SystemParameter)
                .HasForeignKey(d => d.SystemParameterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SystemParameter { Id = 1, Description = "Roles", CreationTime = DateTime.Now },
                new SystemParameter { Id = 2, Description = "Ciclos", CreationTime = DateTime.Now },
                new SystemParameter { Id = 3, Description = "Matriculas", CreationTime = DateTime.Now },
                new SystemParameter { Id = 4, Description = "Porcentaje Calificaciones", CreationTime = DateTime.Now },
                new SystemParameter { Id = 5, Description = "Tipo Calificaciones", CreationTime = DateTime.Now },
                new SystemParameter { Id = 6, Description = "Periodo Calificaciones", CreationTime = DateTime.Now }
            );
        }
    }
}
