using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICalificacionService<T, TDto> : IServiceBase<T, TDto, TDto>
    {
        IEnumerable<T> ObtenerPorCursoYUsuario(long userId, long courseId);
        T ProcesarCalificacionFinal(long matriculaId);
        long ValidarEstadoProcesamiento(long matriculaId);
    }
}
