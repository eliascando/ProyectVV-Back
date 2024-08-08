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
    public class CalificacionRepository : IRepositoryBase<Calificacion>
    {
        private readonly VVContext _context;

        public CalificacionRepository(VVContext context)
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Calificaciones.Where(c => c.Id == id && c.Status == true).FirstOrDefault();

            if (entity == null) throw new Exception("Usuario no encontrado!");

            entity.Status = false;
            _context.Update(entity);
            _context.SaveChanges();

            var val = _context.Calificaciones.Where(c => c.Id == id && c.Status == false).FirstOrDefault();

            return val != null;
        }

        public List<Calificacion> GetAll()
        {
            return _context.Calificaciones.Where(c => c.Status == true).ToList() ?? new List<Calificacion>();
        }

        public Calificacion GetById(long id)
        {
            return _context.Calificaciones.Where(c => c.Id == id && c.Status == true).FirstOrDefault() ?? throw new Exception("No se encontró la calificación!");
        }

        public Calificacion Insert(Calificacion entity)
        {
            _context.Calificaciones.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Calificacion Update(long id, Calificacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
