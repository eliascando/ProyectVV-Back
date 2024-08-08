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
    public class MatriculaConfig : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CourseId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.CreationTime).IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
