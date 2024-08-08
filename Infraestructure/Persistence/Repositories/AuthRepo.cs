using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public class AuthRepo : IAuthRepository<Usuario>
    {
        private readonly VVContext _context;

        public AuthRepo(VVContext context)
        {
            _context = context;
        }

        public Usuario GetByNumberIdentification(string id)
        {
            return _context.Usuarios.Where(u => u.NumberIdentification == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado!");
        }

        public string GetRoleName(string id)
        {
            var user = _context.Usuarios.Where(u => u.NumberIdentification == id).FirstOrDefault();

            var roleName = _context.SystemParametersDetails
                .Where(spd => spd.Id == user.RoleId)
                .Select(spd => spd.Value).FirstOrDefault();

            if (roleName != null)
            {
                return roleName;
            } else
            {
                throw new Exception("Rol no encontrado!");
            }
        }

    }
}
