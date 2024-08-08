using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Security.Jwt
{
    public static class JwtHelper
    {
        public static string GenerateToken(Usuario user, IConfiguration configuration)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            string secret = configuration["JWT:Secret"] ?? throw new Exception("No se pudo generar el token");

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.NumberIdentification),
                    new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenGenerated = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenGenerated);
            return token;
        }
    }
}
