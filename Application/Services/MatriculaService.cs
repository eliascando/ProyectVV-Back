using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MatriculaService : IMatriculaService<Matricula, NewMatriculaDTO, Matricula, MatriculaDTO>
    {
        private readonly IMatriculaRepository<Matricula> _repo;
        private readonly IUsuarioRepository<Usuario> _userRepo;
        private readonly ISystemParameterRepository<SystemParameter, SystemParameterDetails> _paramRepo;
        private readonly ICursoRepository<Curso, CursoDTO> _cursoRepo;

        public MatriculaService(
            IMatriculaRepository<Matricula> repo,
            IUsuarioRepository<Usuario> userRepo,
            ISystemParameterRepository<SystemParameter, SystemParameterDetails> paramRepo,
            ICursoRepository<Curso, CursoDTO> cursoRepo
        )
        {
            _repo = repo;
            _userRepo = userRepo;
            _paramRepo = paramRepo;
            _cursoRepo = cursoRepo;
        }

        public bool Inactivate(long id)
        {
            return _repo.DeleteById(id);
        }

        public Matricula Register(NewMatriculaDTO register)
        {
            // TODO: validar que no este registrado un docente previamente

            Matricula newMatr = new Matricula();
            newMatr.Status = true;
            newMatr.CreationTime = DateTime.Now;
            newMatr.CourseId = register.CourseId;
            newMatr.UserId = register.UserId;
            newMatr.TypeId = register.TypeId;

            return _repo.Insert(newMatr);
        }

        public Matricula UpdateInfo(long id, Matricula update)
        {
            throw new NotImplementedException();
        }

        public List<Matricula> ObtenerTodos()
        {
            return _repo.GetAll();
        }

        public List<MatriculaDTO> ObtenerTodosDto()
        {
            return _repo.GetAll().Select(o => new MatriculaDTO
            {
                Id = o.Id,
                UserName = $"{_userRepo.GetById(o.UserId).Name} {_userRepo.GetById(o.UserId).LastName}",
                TypeName = _paramRepo.GetByDetailId(o.TypeId).Description,
                CourseDescription = $"{_cursoRepo.GetById(o.CourseId).Description} " +
                                    $"| {_cursoRepo.GetById(o.CourseId).Parallel} ",
                Cycle = _paramRepo.GetByDetailId(_cursoRepo.GetById(o.CourseId).CycleId).Description,
                CreationTime = o.CreationTime
            }).ToList();
        }
    }
}
