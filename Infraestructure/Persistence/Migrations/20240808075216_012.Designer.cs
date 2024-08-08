﻿// <auto-generated />
using System;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(VVContext))]
    [Migration("20240808075216_012")]
    partial class _012
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Calificacion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("GradePeriodId")
                        .HasColumnType("bigint");

                    b.Property<long>("GradeType")
                        .HasColumnType("bigint");

                    b.Property<long>("MatriculaId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("Domain.Models.Curso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CycleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Parallel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cursos", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Matricula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Domain.Models.SystemParameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemParameters", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8151),
                            Description = "Roles"
                        },
                        new
                        {
                            Id = 2L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8165),
                            Description = "Ciclos"
                        },
                        new
                        {
                            Id = 3L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8166),
                            Description = "Matriculas"
                        },
                        new
                        {
                            Id = 4L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8167),
                            Description = "Porcentaje Calificaciones"
                        },
                        new
                        {
                            Id = 5L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8168),
                            Description = "Tipo Calificaciones"
                        },
                        new
                        {
                            Id = 6L,
                            CreationTime = new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8169),
                            Description = "Periodo Calificaciones"
                        });
                });

            modelBuilder.Entity("Domain.Models.SystemParameterDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SystemParameterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SystemParameterId");

                    b.ToTable("SystemParameterDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Docente",
                            SystemParameterId = 1L,
                            Value = "DOC"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Estudiante",
                            SystemParameterId = 1L,
                            Value = "EST"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Secretaria",
                            SystemParameterId = 1L,
                            Value = "SEC"
                        },
                        new
                        {
                            Id = 4L,
                            Description = "Administrador",
                            SystemParameterId = 1L,
                            Value = "ADM"
                        },
                        new
                        {
                            Id = 5L,
                            Description = "CICLO I - 2023",
                            SystemParameterId = 2L,
                            Value = "CI2023"
                        },
                        new
                        {
                            Id = 6L,
                            Description = "CICLO II - 2023",
                            SystemParameterId = 2L,
                            Value = "CII2023"
                        },
                        new
                        {
                            Id = 7L,
                            Description = "CICLO I - 2024",
                            SystemParameterId = 2L,
                            Value = "CI2024"
                        },
                        new
                        {
                            Id = 8L,
                            Description = "CICLO II - 2024",
                            SystemParameterId = 2L,
                            Value = "CII2024"
                        },
                        new
                        {
                            Id = 9L,
                            Description = "DOCENTE",
                            SystemParameterId = 3L,
                            Value = "MAT-DOC"
                        },
                        new
                        {
                            Id = 10L,
                            Description = "ESTUDIANTE",
                            SystemParameterId = 3L,
                            Value = "MAT-EST"
                        },
                        new
                        {
                            Id = 11L,
                            Description = "PORC_FORMATIVA",
                            SystemParameterId = 4L,
                            Value = "0.33"
                        },
                        new
                        {
                            Id = 12L,
                            Description = "PORC_PRACTICA",
                            SystemParameterId = 4L,
                            Value = "0.33"
                        },
                        new
                        {
                            Id = 13L,
                            Description = "PORC_ACREDITACION",
                            SystemParameterId = 4L,
                            Value = "0.33"
                        },
                        new
                        {
                            Id = 14L,
                            Description = "FORMATIVA",
                            SystemParameterId = 5L,
                            Value = "T_FORM"
                        },
                        new
                        {
                            Id = 15L,
                            Description = "PRACTICA",
                            SystemParameterId = 5L,
                            Value = "T_PRCT"
                        },
                        new
                        {
                            Id = 16L,
                            Description = "ACREDITACION",
                            SystemParameterId = 5L,
                            Value = "T_ACRE"
                        },
                        new
                        {
                            Id = 17L,
                            Description = "PROMEDIO",
                            SystemParameterId = 5L,
                            Value = "T_TTL"
                        },
                        new
                        {
                            Id = 18L,
                            Description = "PRIMER PARCIAL",
                            SystemParameterId = 6L,
                            Value = "1PARC"
                        },
                        new
                        {
                            Id = 19L,
                            Description = "SEGUNDO PARCIAL",
                            SystemParameterId = 6L,
                            Value = "2PARC"
                        },
                        new
                        {
                            Id = 20L,
                            Description = "PROMEDIO FINAL",
                            SystemParameterId = 6L,
                            Value = "0TOT"
                        });
                });

            modelBuilder.Entity("Domain.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberIdentification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "admin@admin.com",
                            LastName = "",
                            Name = "admin",
                            NumberIdentification = "admin",
                            Password = "$2a$11$RiVVUuif7kw9we7wayBzDOdSikGRzjmus0xMSuwtraRNH1.zNuiha",
                            RoleId = 4L,
                            Status = true
                        });
                });

            modelBuilder.Entity("Domain.Models.SystemParameterDetails", b =>
                {
                    b.HasOne("Domain.Models.SystemParameter", "SystemParameter")
                        .WithMany("Details")
                        .HasForeignKey("SystemParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SystemParameter");
                });

            modelBuilder.Entity("Domain.Models.SystemParameter", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
