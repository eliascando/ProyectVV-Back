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
    public class MatriculaRepository : IMatriculaRepository<Matricula>
    {
        private readonly VVContext _context;

        public MatriculaRepository(VVContext context)
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Matriculas.Where(c => c.Id == id && c.Status == true).FirstOrDefault();

            if (entity == null) throw new Exception("Matricula no encontrada!");

            entity.Status = false;
            _context.Update(entity);
            _context.SaveChanges();

            var val = _context.Cursos.Where(c => c.Id == id && c.Status == false).FirstOrDefault();

            return val != null;
        }

        public List<Matricula> GetAll()
        {
            return _context.Matriculas.Where(m => m.Status == true).ToList();
        }

        public Matricula GetById(long id)
        {
            return _context.Matriculas.Where(c => c.Id == id && c.Status == true).FirstOrDefault() ?? throw new Exception("No se encontró el curso!");
        }

        public Matricula Insert(Matricula entity)
        {
            // validacion docente
            long DOCENTE_MAT_ID = 9;
            long ESTUD_MAT_ID = 10;

            var valDoc = _context.Matriculas.Where(
                x => x.UserId == entity.UserId 
                && x.CourseId == entity.CourseId
                && x.TypeId == DOCENTE_MAT_ID
            ).ToList();

            if (valDoc.Any())
            {
                throw new Exception("Ya existe un docente registrado para este curso!");
            }

            var valEst = _context.Matriculas.Where(
                x => x.UserId == entity.UserId
                && x.CourseId == entity.CourseId
                && x.TypeId == ESTUD_MAT_ID
            ).ToList();

            if (valEst.Any())
            {
                throw new Exception("Ya existe estudiante registrado para este curso!");
            }

            _context.Matriculas.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Matricula> ObtenerPorTipo(long typeId)
        {
            return _context.Matriculas.Where(x => x.TypeId == typeId && x.Status == true).ToList();
        }

        public IEnumerable<Matricula> ObtenerPorUsuario(long userId)
        {
            return _context.Matriculas.Where(x => x.UserId == userId && x.Status == true).ToList();
        }

        public IEnumerable<Matricula> ObtenerPorCurso(long cursoId)
        {
            return _context.Matriculas.Where(x => x.CourseId == cursoId && x.Status == true).ToList();
        }

        public Matricula Update(long id, Matricula entity)
        {
            throw new NotImplementedException();
        }
    }
}
