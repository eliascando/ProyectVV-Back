using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CalificacionService : ICalificacionService<CalificacionDTO, NewCalificacionDTO>
    {
        private readonly ICalificacionRepository<Calificacion, NewCalificacionDTO> _repo;
        private readonly IMatriculaRepository<Matricula> _repoM;
        private readonly ISystemParameterRepository<SystemParameter, SystemParameterDetails> _repoSP;

        public CalificacionService(
            ICalificacionRepository<Calificacion, NewCalificacionDTO> repo,
            IMatriculaRepository<Matricula> repoM,
            ISystemParameterRepository<SystemParameter, SystemParameterDetails> repoSP
        )
        {
            _repo = repo;
            _repoM = repoM;
            _repoSP = repoSP;
        }

        public bool Inactivate(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CalificacionDTO> ObtenerPorCursoYUsuario(long userId, long courseId)
        {
            return _repo.ObtenerPorUsuarioyCurso(userId, courseId).Select(
                    c => new CalificacionDTO()
                    {
                        Id = c.Id,
                        Grade = c.Grade,
                        GradePeriodId = c.GradePeriodId,
                        GradeType = c.GradeType,
                        MatriculaId = c.MatriculaId,
                        GradePeriodName = _repoSP.GetByDetailId(c.GradePeriodId).Description,
                        GradeTypeName = _repoSP.GetByDetailId(c.GradeType).Description,
                    }
                ).ToList();
        }

        public CalificacionDTO ProcesarCalificacionFinal(long matriculaId)
        {
            long PARAM_PORCENTAJE = 4;
            long PARAM_PERIODO = 6;
            long PARAM_PROMEDIO = 17;
            long PARAM_PROMEDIO_FINAL = 20;

            // Obtener el parámetro que contiene los porcentajes
            var porc = _repoSP.GetById(PARAM_PORCENTAJE);

            // Obtener el parámetro que contiene los periodos
            var per = _repoSP.GetById(PARAM_PERIODO);

            var perdos = per.Details.Where(y => y.Id != PARAM_PROMEDIO_FINAL).Select(x => x.Description).ToList();

            // Procesar los porcentajes para los tipos de calificación
            var porcentajes = porc.Details.Select(x => new
            {
                Id = x.Id,
                Descripcion = x.Description.Replace("PORC_", ""),  // Eliminar el prefijo "PORC_" para hacer match
                Value = Convert.ToDecimal(x.Value, CultureInfo.InvariantCulture)
            }).ToList();

            // Obtener las calificaciones por matrícula, excluyendo las calificaciones de tipo promedio
            var calificaciones = _repo.ObtenerPorMatricula(matriculaId)
                .Where(x => x.GradeType != PARAM_PROMEDIO && x.GradeType != PARAM_PROMEDIO_FINAL)
                .ToList();

            // Obtener los promedios ya registrados
            var promediosRegistrados = _repo.ObtenerPromediosPorMatricula(matriculaId);

            // Obtener todos los periodos que existen en las calificaciones
            var periodos = calificaciones.Select(x => x.GradePeriodId).Distinct().ToList();

            // Calcular el puntaje por cada calificación y obtener la descripción del tipo de calificación
            var puntajes = calificaciones.Select(x => new
            {
                Porcentual = x.Grade * (porcentajes.FirstOrDefault(y => y.Descripcion == _repoSP.GetByDetailId(x.GradeType).Description)?.Value ?? 0),
                PeriodoId = x.GradePeriodId,
                TipoId = x.GradeType,
                Calificacion = x.Grade
            }).ToList();

            // Calcular el promedio por periodo
            var promediosPorPeriodo = puntajes
                .GroupBy(x => x.PeriodoId)
                .Select(grupo => new
                {
                    PeriodoId = grupo.Key,
                    Promedio = grupo.Sum(g => g.Porcentual),
                    TotalTipos = grupo.Select(g => g.TipoId).Distinct().Count()  // Contar los tipos distintos por periodo
                })
                .Where(p => !promediosRegistrados.Any(pr => pr.GradePeriodId == p.PeriodoId)) // Filtrar períodos que ya están registrados
                .ToList();

            Calificacion c = null;

            // Verificar si el promedio para todos los tipos de calificaciones en cada periodo
            foreach (var periodo in promediosPorPeriodo)
            {
                if (periodo.TotalTipos == porcentajes.Count()) // Solo si todos los tipos están presentes
                {
                    Calificacion promedio = new Calificacion()
                    {
                        MatriculaId = matriculaId,
                        Grade = periodo.Promedio,
                        Status = true,
                        GradeType = PARAM_PROMEDIO,
                        GradePeriodId = periodo.PeriodoId
                    };
                    c = _repo.Insert(promedio);
                }
            }

            // Calcular el promedio final solo si todos los periodos posibles están completos
            var totalPeriodos = perdos.Count(); //porcentajes.Select(x => x.Descripcion).Distinct().Count(); //puntajes.Select(x => x.PeriodoId).Distinct().Count();
            var totalPeriodosCompletados = promediosRegistrados.Count() + promediosPorPeriodo.Count();

            // Verificar si el promedio final ya está registrado y que todos los periodos están completos
            var promedioFinalRegistrado = promediosRegistrados.Any(pr => pr.GradeType == PARAM_PROMEDIO_FINAL);

            if (!promedioFinalRegistrado && totalPeriodosCompletados == totalPeriodos)
            {
                var promedioFinal = (promediosRegistrados.Sum(x => x.Grade) + promediosPorPeriodo.Sum(x => x.Promedio)) / totalPeriodos;

                Calificacion final = new Calificacion()
                {
                    MatriculaId = matriculaId,
                    Grade = promedioFinal,
                    Status = true,
                    GradeType = PARAM_PROMEDIO_FINAL,
                    GradePeriodId = PARAM_PROMEDIO_FINAL
                };

                c = _repo.Insert(final);

                var m = _repoM.GetById(matriculaId);

                m.StatusApprove = ObtenerEstado(promedioFinal);

                _repoM.Update(matriculaId, m);

                return new CalificacionDTO()
                {
                    Id = c.Id,
                    Grade = c.Grade,
                    GradePeriodId = c.GradePeriodId,
                    GradeType = c.GradeType,
                    MatriculaId = c.MatriculaId,
                    GradePeriodName = _repoSP.GetByDetailId(c.GradePeriodId).Description,
                    GradeTypeName = _repoSP.GetByDetailId(c.GradeType).Description,
                };
            }

            // Retornar null o un DTO vacío si no se pudo calcular el promedio final
            return new CalificacionDTO()
            {
                Id = c?.Id ?? 0,
                Grade = c?.Grade ?? 0,
                GradePeriodId = c?.GradePeriodId ?? 0,
                GradeType = c?.GradeType ?? 0,
                MatriculaId = c?.MatriculaId ?? matriculaId,
                GradePeriodName = c != null ? _repoSP.GetByDetailId(c.GradePeriodId).Description : "",
                GradeTypeName = c != null ? _repoSP.GetByDetailId(c.GradeType).Description : "",
            };
        }


        private string ObtenerEstado(decimal c)
        {
            if (c >= 7)
            {
                return "APROBADO";
            }
            else if (c < 7)
            {
                return "REPROBADO";
            }

            return "";
        }

        public long ValidarEstadoProcesamiento(long matriculaId)
        {
            long PARAM_PORCENTAJE = 4;
            long PARAM_PROMEDIO = 17;
            long PARAM_PROMEDIO_FINAL = 20;

            // Obtener todas las calificaciones por matrícula, excluyendo las calificaciones de tipo promedio
            var calificaciones = _repo.ObtenerPorMatricula(matriculaId)
                .Where(x => x.GradeType != PARAM_PROMEDIO && x.GradeType != PARAM_PROMEDIO_FINAL)
                .ToList();

            // Obtener todos los periodos que existen en las calificaciones
            var periodos = calificaciones.Select(x => x.GradePeriodId).Distinct().ToList();

            // Obtener los promedios ya registrados
            var promediosRegistrados = _repo.ObtenerPromediosPorMatricula(matriculaId);

            // Contar los periodos completos (donde se han registrado todos los tipos de calificaciones)
            var totalTiposRequeridos = _repoSP.GetById(PARAM_PORCENTAJE).Details.Where(x=>x.Id != PARAM_PROMEDIO_FINAL).Select(x => x.Id).Count();//calificaciones.Select(x => x.GradeType).Distinct().Count();
            var periodosCompletos = calificaciones
                .GroupBy(x => x.GradePeriodId)
                .Where(grupo => grupo.Select(g => g.GradeType).Distinct().Count() == totalTiposRequeridos)
                .Select(grupo => grupo.Key)
                .ToList();

            // Verificar si el promedio final ya está registrado
            var promedioFinalRegistrado = promediosRegistrados.Any(pr => pr.GradeType == PARAM_PROMEDIO_FINAL);

            // Caso 1: Si tiene un periodo completo pero aún no se ha calculado el promedio final
            if (periodosCompletos.Count() > promediosRegistrados.Count() && !promedioFinalRegistrado)
            {
                return 1;
            }

            // Caso 2: Si no tiene un periodo completo
            if (periodosCompletos.Count < periodos.Count)
            {
                return 2;
            }

            // Caso 3: Si todos los periodos están completos y el promedio final está registrado
            if (periodosCompletos.Count == periodos.Count && promedioFinalRegistrado)
            {
                return 3;
            }

            // Caso por defecto: Devolver '2' si aún no hay suficientes datos para procesar
            return 2;
        }

        public CalificacionDTO Register(NewCalificacionDTO register)
        {
            Calificacion calificacion = new Calificacion()
            {
                Grade = register.calificacion,
                GradePeriodId = register.periodoCalificacion,
                GradeType = register.tipoCalificacion,
                MatriculaId = _repoM.ObtenerPorUsuarioAndCourse(register.idUsuario, register.idCurso).Id,
                Status = true
            };

            var c = _repo.Insert(calificacion);

            return new CalificacionDTO()
            {
                Id = c.Id,
                Grade = c.Grade,
                GradePeriodId = c.GradePeriodId,
                GradeType = c.GradeType,
                MatriculaId = c.MatriculaId,
                GradePeriodName = _repoSP.GetByDetailId(c.GradePeriodId).Description,
                GradeTypeName = _repoSP.GetByDetailId(c.GradeType).Description,
            };
        }

        public CalificacionDTO UpdateInfo(long id, NewCalificacionDTO update)
        {
            throw new NotImplementedException();
        }
    }
}
