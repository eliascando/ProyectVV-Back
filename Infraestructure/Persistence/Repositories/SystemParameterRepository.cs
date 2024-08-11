using Domain.Interfaces.Repositories;
using Domain.Models;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class SystemParameterRepository : ISystemParameterRepository<SystemParameter, SystemParameterDetails>
    {
        private readonly VVContext _context;

        public SystemParameterRepository(VVContext context)
        {
            _context = context;
        }

        public List<SystemParameter> GetAll()
        {
            return _context.SystemParameters.Include(sp => sp.Details).ToList();
        }

        public SystemParameterDetails GetByDetailId(long id)
        {
            return _context.SystemParametersDetails.Where(spd => spd.Id == id).FirstOrDefault() ?? throw new Exception("No se encontró detalle!");
        }

        public SystemParameter GetById(long id)
        {
            return _context.SystemParameters.Where(sp => sp.Id == id).Include(sp => sp.Details).FirstOrDefault() ?? throw new Exception("No se encontró parametro");
        }

        public List<SystemParameter> ObtenerDropDownsPorEstudiante(long idUser, long idCurso)
        {
            long ID_TIPO = 5;
            long ID_PERIODO = 6;

            var tiposParams = new List<long>()
            {
                ID_TIPO,
                ID_PERIODO
            };

            // IDs específicos que deben ser excluidos
            var idsExcluidos = new List<long> { 17, 20 };

            // Obtener la matrícula para el estudiante y el curso
            var matriculaIds = _context.Matriculas
                .Where(x => x.UserId == idUser && x.CourseId == idCurso)
                .Select(x => x.Id)
                .ToList();

            // Obtener los tipos de calificación y periodos ya utilizados
            var calificacionesExistentes = _context.Calificaciones
                .Where(x => matriculaIds.Contains(x.MatriculaId))
                .Select(x => new { x.GradeType, x.GradePeriodId })
                .ToList();

            // Cargar los SystemParameters en memoria
            var parametros = _context.SystemParameters
                .Where(sp => tiposParams.Contains(sp.Id))
                .Include(sp => sp.Details)
                .ToList();

            // Identificar los detalles del primer y segundo periodo
            var detallesPeriodos = parametros
                .FirstOrDefault(sp => sp.Id == ID_PERIODO)?.Details
                .Where(detail => !idsExcluidos.Contains(detail.Id))
                .OrderBy(detail => detail.Id)
                .ToList();

            if (detallesPeriodos == null || detallesPeriodos.Count < 2)
            {
                // Si no hay suficientes periodos o si no se pueden identificar correctamente
                return new List<SystemParameter>();
            }

            var primerPeriodoId = detallesPeriodos.First().Id;
            var segundoPeriodoId = detallesPeriodos.Last().Id;

            // Verificar si el primer periodo tiene todos los tipos de calificación
            var tiposFaltantesPrimerPeriodo = parametros
                .FirstOrDefault(sp => sp.Id == ID_TIPO)?.Details
                .Where(detail => !idsExcluidos.Contains(detail.Id))
                .Where(detail => !calificacionesExistentes.Any(cal =>
                    cal.GradeType == detail.Id && cal.GradePeriodId == primerPeriodoId))
                .ToList();

            bool primerPeriodoCompleto = tiposFaltantesPrimerPeriodo == null || !tiposFaltantesPrimerPeriodo.Any();

            // Si el primer periodo está completo, verificar si el segundo también lo está
            bool segundoPeriodoCompleto = primerPeriodoCompleto && parametros
                .FirstOrDefault(sp => sp.Id == ID_TIPO)?.Details
                .Where(detail => !idsExcluidos.Contains(detail.Id))
                .Where(detail => !calificacionesExistentes.Any(cal =>
                    cal.GradeType == detail.Id && cal.GradePeriodId == segundoPeriodoId))
                .ToList()
                .Any() == false;

            // Si ambos periodos están completos, no se devuelve ningún SystemParameter
            if (primerPeriodoCompleto && segundoPeriodoCompleto)
            {
                return new List<SystemParameter>();
            }

            // Filtrar los parámetros
            var parametrosFiltrados = parametros
                .Select(sp => new SystemParameter
                {
                    Id = sp.Id,
                    Description = sp.Description,
                    CreationTime = sp.CreationTime,
                    Details = sp.Details
                        .Where(detail =>
                            !idsExcluidos.Contains(detail.Id) &&
                            (
                                // Tipos de calificación
                                (sp.Id == ID_TIPO &&
                                 (
                                    // Si el primer periodo está incompleto, solo mostrar tipos no usados en el primer periodo
                                    !primerPeriodoCompleto && !calificacionesExistentes.Any(cal => cal.GradeType == detail.Id && cal.GradePeriodId == primerPeriodoId) ||

                                    // Si el primer periodo está completo, solo mostrar tipos no usados en el segundo periodo
                                    primerPeriodoCompleto && !calificacionesExistentes.Any(cal => cal.GradeType == detail.Id && cal.GradePeriodId == segundoPeriodoId)
                                 )) ||

                                // Periodos: si el primer periodo está completo, mostrar solo el segundo periodo
                                (sp.Id == ID_PERIODO &&
                                 (
                                    primerPeriodoCompleto && !segundoPeriodoCompleto && detail.Id == segundoPeriodoId ||
                                    !primerPeriodoCompleto && detail.Id == primerPeriodoId
                                 ))
                            )
                        )
                        .ToList()
                })
                .Where(sp => sp.Details.Any()) // Filtrar los parámetros que aún tienen detalles disponibles
                .ToList();

            return parametrosFiltrados;
        }

        public SystemParameter RegisterNew(SystemParameter entity)
        {
            _context.SystemParameters.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
