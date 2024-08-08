using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CursoService : ICursoService<Curso, NewCursoDTO, UpdateCursoDTO, CursoDTO>
    {
        private ICursoRepository<Curso, CursoDTO> _courseRepo;

        public CursoService(ICursoRepository<Curso, CursoDTO> repo)
        {
            _courseRepo = repo;
        }

        public bool Inactivate(long id)
        {
            return _courseRepo.DeleteById(id);
        }

        public Curso Register(NewCursoDTO register)
        {
            Curso newCurso = new Curso();
            newCurso.Status = true;
            newCurso.Description = register.Description;
            newCurso.Parallel = register.Parallel;
            newCurso.CycleId = register.CycleId;
            newCurso.Price = register.Price;
            newCurso.Hours = register.Hours;

            var user = _courseRepo.Insert(newCurso);

            return user;
        }

        public Curso UpdateInfo(long id, UpdateCursoDTO update)
        {
            Curso updCurso = new Curso();
            updCurso.Status = true;
            updCurso.Description = update.Description;
            updCurso.Price = update.Price;
            updCurso.Hours = update.Hours;

            var user = _courseRepo.Update(id, updCurso);

            return user;
        }

        public List<Curso> ObtenerTodos()
        {
            return _courseRepo.GetAll();
        }

        public List<CursoDTO> ObtenerTodosDto()
        {
            return _courseRepo.ObtenerCursosDto();
        }
    }
}
