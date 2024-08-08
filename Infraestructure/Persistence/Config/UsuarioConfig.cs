using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.NumberIdentification).IsRequired(true);
            builder.Property(u => u.Name).IsRequired(true);
            builder.Property(u => u.LastName).IsRequired(true);
            builder.Property(u => u.Email).IsRequired(true);
            builder.Property(u => u.Password).IsRequired(true);
            builder.Property(u => u.Phone).IsRequired(false);
            builder.Property(u => u.Adress).IsRequired(false);
            builder.Property(u => u.RoleId).IsRequired(true);

            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasData(
                new Usuario { 
                    Id = 1, 
                    NumberIdentification = "0000", 
                    Password = "$2a$11$RiVVUuif7kw9we7wayBzDOdSikGRzjmus0xMSuwtraRNH1.zNuiha", 
                    Name = "admin", 
                    LastName="", 
                    Email = "admin@admin.com",
                    RoleId = 4,
                    Status = true
                }
            );
        }
    }
}
