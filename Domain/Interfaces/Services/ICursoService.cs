using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICursoService<T, TRegister, TUpdate, TDTO> : IServiceBase<T, TRegister, TUpdate>
    {
        List<T> ObtenerTodos();
        List<TDTO> ObtenerTodosDto();
        TDTO ObtenerDto(long id);
        List<TDTO> ObtenerCursosPorDocente(long id);
    }
}
