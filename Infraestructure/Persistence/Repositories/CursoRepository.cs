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
    public class CursoRepository : ICursoRepository<Curso, CursoDTO>
    {
        private readonly VVContext _context;

        public CursoRepository(VVContext context)
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Cursos.Where(c => c.Id == id && c.Status == true).FirstOrDefault();

            if (entity == null) throw new Exception("Curso no encontrado!");

            entity.Status = false;
            _context.Update(entity);
            _context.SaveChanges();

            var val = _context.Cursos.Where(c => c.Id == id && c.Status == false).FirstOrDefault();

            return val != null;
        }

        public List<Curso> GetAll()
        {
            return _context.Cursos.Where(c => c.Status == true).ToList() ?? new List<Curso>();
        }

        public Curso GetById(long id)
        {
            return _context.Cursos.Where(c => c.Id == id && c.Status == true).FirstOrDefault() ?? throw new Exception("No se encontró el curso!");
        }

        public Curso Insert(Curso entity)
        {
            _context.Cursos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Curso Update(long id, Curso entity)
        {
            var c = _context.Cursos.Where(u => u.Id == id && u.Status == true).FirstOrDefault() ?? throw new Exception("Curso no encontrado!");

            c.Description = entity.Description;
            c.Price = entity.Price;
            c.Hours = entity.Hours;
            
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();

            return c;
        }

        public List<CursoDTO> ObtenerCursosDto()
        {
            // matricula tipo estudiante
            long MATRICULA_ESTUDIANTE_ID = 10;

            var cursos = _context.Cursos.Where(c=>c.Status).Select(
                    c => new CursoDTO
                    {
                        Cycle = _context.SystemParametersDetails.Where(sp => sp.Id == c.CycleId).Select(c => c.Description).FirstOrDefault() ?? "",
                        Hours = c.Hours,
                        Description = c.Description,
                        Id = c.Id,
                        Status = c.Status,
                        Parallel = c.Parallel,
                        Price = c.Price,
                        StudentsRegistered = _context.Matriculas.Where(m => (m.CourseId == c.Id) && m.Status && m.TypeId == MATRICULA_ESTUDIANTE_ID).Count()
                    }
                ).ToList();

            return cursos;
        }

        public List<CursoDTO> ObtenerCursosPorDocente(long id)
        {
            // matricula tipos
            long MATRICULA_DOCENTE_ID = 9;
            long MATRICULA_ESTUDIANTE_ID = 10;

            var matriculas = _context.Matriculas.Where(
                                  x => x.UserId == id
                                  && x.Status == true
                                  && x.TypeId == MATRICULA_DOCENTE_ID
                             ).Select(x => x.CourseId).ToList() ?? throw new Exception("No se encontraron matriculas!");

            var cursos = _context.Cursos.Where(
                        c => c.Status && matriculas.Contains(c.Id)
                    ).Select(
                    c => new CursoDTO
                    {
                        Cycle = _context.SystemParametersDetails.Where(sp => sp.Id == c.CycleId).Select(c => c.Description).FirstOrDefault() ?? "",
                        Hours = c.Hours,
                        Description = c.Description,
                        Id = c.Id,
                        Status = c.Status,
                        Parallel = c.Parallel,
                        Price = c.Price,
                        StudentsRegistered = _context.Matriculas.Where(m => (m.CourseId == c.Id) && m.Status && m.TypeId == MATRICULA_ESTUDIANTE_ID).Count()
                    }
                ).ToList();

            return cursos;
        }
    }
}
