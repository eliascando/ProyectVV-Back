using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class SystemParameterService : ISystemParameterService<SystemParameter, SystemParameterDetails>
    {
        private readonly ISystemParameterRepository<SystemParameter, SystemParameterDetails> _repo;

        public SystemParameterService(ISystemParameterRepository<SystemParameter, SystemParameterDetails> repo)
        {
            _repo = repo;
        }

        public List<SystemParameter> ObtenerDropDownsPorEstudiante(long idUser, long idCurso)
        {
            return _repo.ObtenerDropDownsPorEstudiante(idUser, idCurso);
        }

        public SystemParameter ObtenerPorId(long id)
        {
            return _repo.GetById(id);
        }

        public List<SystemParameter> ObtenerTodos()
        {
            return _repo.GetAll();
        }

        public SystemParameter Register(SystemParameter entity)
        {
            var reg = _repo.RegisterNew(entity);
            if (reg != null) return reg;

            throw new Exception("Error al registrar");
        }
    }
}
