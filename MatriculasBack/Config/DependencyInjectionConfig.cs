using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace MatriculasBack.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // add services
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // custom services
            services.AddScoped<UsuarioService>();
            services.AddScoped<AuthService>();
            services.AddScoped<CursoService>();
            services.AddScoped<MatriculaService>();
            services.AddScoped<SystemParameterService>();

            // implement services
            services.AddScoped<IUsuarioService<NewUserDTO, UsuarioRegistroDTO, UpdateUser>, UsuarioService>();
            services.AddScoped<IAuthService<Usuario, LoginDTO, LoginResultDTO>, AuthService>();
            services.AddScoped<ICursoService<Curso, NewCursoDTO, UpdateCursoDTO, CursoDTO>, CursoService>();
            services.AddScoped<IMatriculaService<Matricula, NewMatriculaDTO, Matricula>, MatriculaService>();
            services.AddScoped<ISystemParameterService<SystemParameter, SystemParameterDetails>, SystemParameterService>();

            // add repos
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<AuthRepo>();
            services.AddScoped<CursoRepository>();
            services.AddScoped<MatriculaRepository>();
            services.AddScoped<SystemParameterRepository>();

            // implement repos
            services.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository>();
            services.AddScoped<IAuthRepository<Usuario>, AuthRepo>();
            services.AddScoped<ICursoRepository<Curso, CursoDTO>, CursoRepository>();
            services.AddScoped<IMatriculaRepository<Matricula>, MatriculaRepository>();
            services.AddScoped<ISystemParameterRepository<SystemParameter, SystemParameterDetails>, SystemParameterRepository>();

            // add cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // add dbcontext
            services.AddDbContext<VVContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Master"));
            });

            return services;
        }
    }
}
