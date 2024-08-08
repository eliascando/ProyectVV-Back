using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Infraestructure.Security.Jwt;
using System.Diagnostics;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class AuthService : IAuthService<Usuario, LoginDTO, LoginResultDTO>
    {
        private readonly IConfiguration _config;
        private readonly IAuthRepository<Usuario> _repo;

        public AuthService(
            IConfiguration configuration,
            IAuthRepository<Usuario> repo
        )
        {
            _config = configuration;
            _repo = repo;
        }

        public LoginResultDTO Login(LoginDTO login)
        {
            var usuario = _repo.GetByNumberIdentification(login.NumberIdentification);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado!");
            }

            if (BCrypt.Net.BCrypt.Verify(login.Password, usuario.Password))
            {
                var roleName = _repo.GetRoleName(login.NumberIdentification);
                var token = JwtHelper.GenerateToken(usuario, _config);

                if (token == null)
                {
                    throw new Exception("Error al generar el token!");
                }

                LoginResultDTO res = new LoginResultDTO()
                {
                    Id = usuario.Id,
                    NumberIdentification = usuario.NumberIdentification,
                    RoleName = roleName,
                    Token = token,
                    CompleteName = $"{usuario.Name} {usuario.LastName}",
                    Email = usuario.Email,
                    RoleId = usuario.RoleId
                };

                return res;
            } 
            else
            {
                throw new Exception("Contraseña incorrecta!");
            }
                
        }
    }
}
