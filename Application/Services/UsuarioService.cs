using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Infraestructure.Persistence.Context;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService<NewUserDTO, UsuarioRegistroDTO, UpdateUser>
    {

        private readonly IUsuarioRepository<Usuario> _userRepo;
        private readonly ISystemParameterRepository<SystemParameter, SystemParameterDetails> _repoSp;

        public UsuarioService(IUsuarioRepository<Usuario> repo, ISystemParameterRepository<SystemParameter, SystemParameterDetails> repoSp)
        {
            _userRepo = repo;
            _repoSp = repoSp;
        }

        public NewUserDTO Register(UsuarioRegistroDTO register)
        {
            Usuario newUser = new Usuario();
            newUser.Status = true;
            newUser.NumberIdentification = register.NumberIdentification;
            newUser.Name = register.Name;
            newUser.LastName = register.LastName;
            newUser.Email = register.Email;
            newUser.RoleId = register.RoleId;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(register.Password);

            var user = _userRepo.Insert(newUser);

            return new NewUserDTO()
            {
                Id = user.Id,
                NumberIdentification = user.NumberIdentification,
                Name = user.Name,
                LastName = user.LastName,
                Phone = user.Phone,
                Adress = user.Adress,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == user.RoleId).FirstOrDefault().Value ?? ""
            };
        }

        public NewUserDTO UpdateInfo(long id, UpdateUser update)
        {
            Usuario updUser = new Usuario();

            updUser.Email = update.Email;
            updUser.Phone = update.Phone;
            updUser.Adress = update.Adress;
            updUser.Password = BCrypt.Net.BCrypt.HashPassword(update.Password);
            updUser.RoleId = update.RoleId;

            var user = _userRepo.Update(id, updUser);

            return new NewUserDTO()
            {
                Id = user.Id,
                NumberIdentification = user.NumberIdentification,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Adress = user.Adress,
                RoleId = user.RoleId,
                RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == user.RoleId).FirstOrDefault().Value ?? ""
            };
        }

        public bool Inactivate(long id)
        {
            return _userRepo.DeleteById(id);
        }

        public List<NewUserDTO> ObtenerEstudiantesPorCurso(long cursoId)
        {
           long DOCENTE_TYPE_ID = 10;
           return _userRepo
                .ObtenerPorCursoId(cursoId, DOCENTE_TYPE_ID)
                .Select(u => new NewUserDTO()
                {
                    Id = u.Id,
                    NumberIdentification = u.NumberIdentification,
                    Name = u.Name,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone,
                    Adress = u.Adress,
                    RoleId = u.RoleId,
                    RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                }).ToList();
        }

        public List<NewUserDTO> ObtenerDocentesPorCurso(long cursoId)
        {
            long ESTUDIANTE_TYPE_ID = 10;
            return _userRepo
                 .ObtenerPorCursoId(cursoId, ESTUDIANTE_TYPE_ID)
                 .Select(u => new NewUserDTO()
                 {
                     Id = u.Id,
                     NumberIdentification = u.NumberIdentification,
                     Name = u.Name,
                     LastName = u.LastName,
                     Email = u.Email,
                     Phone= u.Phone,
                     Adress = u.Adress,
                     RoleId = u.RoleId,
                     RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                 }).ToList();
        }

        public List<NewUserDTO> ObtenerTodosPorCursoId(long cursoId)
        {
            return _userRepo
                 .ObtenerPorCursoId(cursoId)
                 .Select(u => new NewUserDTO()
                 {
                     Id = u.Id,
                     NumberIdentification = u.NumberIdentification,
                     Name = u.Name,
                     LastName = u.LastName,
                     Email = u.Email,
                     Phone= u.Phone,
                     Adress = u.Adress,
                     RoleId = u.RoleId,
                     RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                 }).ToList();
        }

        public List<NewUserDTO> ObtenerDocentes()
        {
            long ROL_DOCENTE = 1;
            return _userRepo
                 .ObtenerUsuariosPorRol(ROL_DOCENTE)
                 .Select(u => new NewUserDTO()
                 {
                     Id = u.Id,
                     NumberIdentification = u.NumberIdentification,
                     Name = u.Name,
                     LastName = u.LastName,
                     Email = u.Email,
                     Phone= u.Phone,
                     Adress = u.Adress,
                     RoleId = u.RoleId,
                     RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                 }).ToList();
        }

        public List<NewUserDTO> ObtenerEstudiantes()
        {
            long ROL_ESTUDIANTE = 2;
            return _userRepo
                 .ObtenerUsuariosPorRol(ROL_ESTUDIANTE)
                 .Select(u => new NewUserDTO()
                 {
                     Id = u.Id,
                     NumberIdentification = u.NumberIdentification,
                     Name = u.Name,
                     LastName = u.LastName,
                     Email = u.Email,
                     Phone= u.Phone,
                     Adress = u.Adress,
                     RoleId = u.RoleId,
                     RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                 }).ToList();
        }

        public List<NewUserDTO> ObtenerTodos()
        {
            return _userRepo
                 .GetAll()
                 .Select(u => new NewUserDTO()
                 {
                     Id = u.Id,
                     NumberIdentification = u.NumberIdentification,
                     Name = u.Name,
                     LastName = u.LastName,
                     Email = u.Email,
                     Phone = u.Phone,
                     Adress = u.Adress,
                     RoleId = u.RoleId,
                     RoleName = _repoSp.GetById(1).Details.Where(x => x.Id == u.RoleId).FirstOrDefault().Value ?? ""
                 }).ToList();
        }
    }
}
