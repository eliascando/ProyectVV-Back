using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public class CalificacionRepository : ICalificacionRepository<Calificacion, NewCalificacionDTO>
    {
        private readonly VVContext _context;

        public CalificacionRepository(VVContext context)
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Calificaciones.Where(c => c.Id == id && c.Status == true).FirstOrDefault();

            if (entity == null) throw new Exception("Calificacion no encontrado!");

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

        public IEnumerable<Calificacion> ObtenerPorMatricula(long matricula)
        {
            var c = _context.Calificaciones.Where(x => x.MatriculaId == matricula).ToList();
            return c;
        }

        public IEnumerable<Calificacion> ObtenerPorUsuarioyCurso(long user, long curso)
        {
            var mat = _context.Matriculas.Where(x => x.UserId == user && x.CourseId == curso && x.Status == true).FirstOrDefault();
            var c = _context.Calificaciones.Where(x => x.MatriculaId == mat.Id).ToList();
            return c;
        }

        public IEnumerable<Calificacion> ObtenerPromediosPorMatricula(long matricula)
        {
            var promediosIdType = new List<long> { 17, 20 }; // 17 promedio por periodo , 20 promedio final
            var c = _context.Calificaciones.Where(x => x.MatriculaId == matricula && promediosIdType.Contains(x.GradeType)).ToList();
            return c;
        }

        public Calificacion Update(long id, Calificacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
