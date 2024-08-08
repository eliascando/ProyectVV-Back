using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository<Usuario>
    {
        private readonly VVContext _context;
        public UsuarioRepository(VVContext context) 
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Usuarios.Where(u => u.Id == id && u.Status == true).FirstOrDefault();

            if (entity == null) throw new Exception("Usuario no encontrado!");

            entity.Status = false;
            _context.Update(entity);
            _context.SaveChanges();

            var val = _context.Usuarios.Where(u => u.Id == id && u.Status == false).FirstOrDefault();

            return val != null;
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.Where(u => u.Status == true).ToList() ?? new List<Usuario>();
        }

        public Usuario GetById(long id)
        {
            return _context.Usuarios.Where(u => u.Id == id && u.Status == true).FirstOrDefault() ?? throw new Exception("Usuario no encontrado!");
        }

        public Usuario Insert(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<Usuario> ObtenerPorCursoId(long cursoId, long typeId = 0)
        {

            if (!_context.Cursos.Any(c => (c.Id == cursoId) && c.Status)) throw new Exception("No se encontró curso!");

            var idS = typeId == 0 // si es todos es tipo 0, no se le manda por parámetros
                ? _context.Matriculas
                .Where(m => (m.CourseId == cursoId) && m.Status)
                .Select(m => m.UserId)
                .ToList() 
                : _context.Matriculas // si no es tipo 0 entonces se tiene que filtrar por tipo de matricula
                .Where(m => (m.CourseId == cursoId) && m.TypeId == typeId && m.Status)
                .Select(m => m.UserId)
                .ToList() 
                ?? throw new Exception("No se encontraron matriculados!");

            var usuarios = _context.Usuarios
                .Where(u => idS.Contains(u.Id) && u.Status)
                .ToList() ?? throw new Exception("No se encontraon matriculados!");

            return usuarios;
        }

        public List<Usuario> ObtenerUsuariosPorRol(long roleId)
        {
            return _context.Usuarios.Where(u => u.Status == true && u.RoleId == roleId).ToList() ?? new List<Usuario>();
        }

        public Usuario Update(long id, Usuario entity)
        {
            var u = _context.Usuarios.Where(u => u.Id == id && u.Status == true).FirstOrDefault() ?? throw new Exception("Usuario no encontrado!");
            
            u.Email = (entity.Email == String.Empty || entity.Phone == null) ? u.Email : entity.Email;
            u.Phone = (entity.Phone == String.Empty || entity.Phone == null) ? u.Phone : entity.Phone;
            u.Adress = (entity.Adress == String.Empty || entity.Adress == null) ? u.Adress : entity.Adress;
            u.Password = (entity.Password == String.Empty || entity.Password == null) ? u.Password : entity.Password;
            u.RoleId = (entity.RoleId == null || entity.RoleId == 0) ? u.RoleId : entity.RoleId;

            _context.Entry(u).State = EntityState.Modified;
            _context.SaveChanges();

            return u;
        }
    }
}
