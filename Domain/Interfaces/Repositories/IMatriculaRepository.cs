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
        T ObtenerPorUsuarioAndCourse(long userId, long courseId);
        IEnumerable<T> ObtenerPorCurso(long cursoId);
    }
}
