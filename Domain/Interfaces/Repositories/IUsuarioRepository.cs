using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository<T> : IRepositoryBase<T>
    {
        List<T> ObtenerPorCursoId(long cursoId, long typeId=0);
        List<T> ObtenerUsuariosPorRol(long roleId);
    }
}
