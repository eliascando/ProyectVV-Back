using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISystemParameterService<T, TDetails>
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(long id);
        T Register(T entity);
        List<T> ObtenerDropDownsPorEstudiante(long idUser, long idCurso);

    }
}
