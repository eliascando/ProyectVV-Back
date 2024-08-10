using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService<T, TRegister, TUpdate> : IServiceBase<T, TRegister, TUpdate>
    {
        List<T> ObtenerEstudiantesPorCurso(long cursoId);
        List<T> ObtenerDocentesPorCurso(long cursoId);
        List<T> ObtenerTodosPorCursoId(long cursoId);
        List<T> ObtenerDocentes();
        List<T> ObtenerEstudiantes();
        List<T> ObtenerTodos();
    }
}
