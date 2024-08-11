using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTesting.Tests.PruebasIntegracion
{
    public class IntegrationTestBase : IDisposable
    {
        protected readonly VVContext _context;
        protected readonly IUsuarioRepository<Usuario> _usuarioRepository;
        protected readonly UsuarioService _usuarioService;

        public IntegrationTestBase()
        {
            var services = new ServiceCollection();

            // Configura el DbContext para usar la base de datos en memoria
            services.AddDbContext<VVContext>(options =>
                options.UseInMemoryDatabase("TestDatabase"));

            // Configura las dependencias
            services.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository>();
            services.AddScoped<UsuarioService>();

            var serviceProvider = services.BuildServiceProvider();

            _context = serviceProvider.GetRequiredService<VVContext>(); // Usa VVContext
            _usuarioRepository = serviceProvider.GetRequiredService<IUsuarioRepository<Usuario>>();
            _usuarioService = serviceProvider.GetRequiredService<UsuarioService>();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Agrega datos iniciales a la base de datos en memoria para las pruebas
            _context.SystemParameters.Add(new SystemParameter
            {
                Id = 1,
                Details = new List<SystemParameterDetails>
            {
                new SystemParameterDetails { Id = 1, Value = "Admin" },
                new SystemParameterDetails { Id = 2, Value = "Student" },
                new SystemParameterDetails { Id = 3, Value = "Teacher" }
            }
            });

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
