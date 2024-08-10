using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMatriculaService<T, TRegister, TUpdate, TDto> : IServiceBase<T, TRegister, TUpdate>
    {
        List<T> ObtenerTodos();
        List<TDto> ObtenerTodosDto();
    }
}
