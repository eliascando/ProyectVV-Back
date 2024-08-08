using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMatriculaRepository<T> : IRepositoryBase<T>
    {
        IEnumerable<T> ObtenerPorUsuario(long userId);
        IEnumerable<T> ObtenerPorTipo(long typeId);
        IEnumerable<T> ObtenerPorCurso(long cursoId);
    }
}
