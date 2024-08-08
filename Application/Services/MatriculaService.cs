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
    public class MatriculaService : IMatriculaService<Matricula, NewMatriculaDTO, Matricula>
    {
        private readonly IMatriculaRepository<Matricula> _repo;

        public MatriculaService(IMatriculaRepository<Matricula> repo)
        {
            _repo = repo;
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
    }
}
