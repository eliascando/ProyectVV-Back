using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculasBack.Controllers
{
    [Route("api/calificacion")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly CalificacionService _serv;

        public CalificacionesController(CalificacionService serv)
        {
            _serv = serv;
        }

        // GET: api/calificacion/{idUser}/{idCurso}
        [HttpGet("{idUser}/{idCurso}")]
        public ApiResponse<IEnumerable<CalificacionDTO>> GetByUserAndCourse(long idUser, long idCurso)
        {
            try
            {
                var res = _serv.ObtenerPorCursoYUsuario(idUser, idCurso);

                if (res == null) return ApiResponse<IEnumerable<CalificacionDTO>>.ErrorResponse("Error");

                return ApiResponse<IEnumerable<CalificacionDTO>>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CalificacionDTO>>.ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // POST api/calificacion
        [HttpPost]
        public ApiResponse<CalificacionDTO> Post([FromBody] NewCalificacionDTO nuevo)
        {
            try
            {
                var res = _serv.Register(nuevo);

                if (res == null) return ApiResponse<CalificacionDTO>.ErrorResponse("Error");

                return ApiResponse<CalificacionDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<CalificacionDTO>.ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

        }

        // POST api/calificacion/procesar
        [HttpPost("procesar/{matriculaId}")]
        public ApiResponse<CalificacionDTO> PostCalculate(long matriculaId)
        {
            try
            {
                var res = _serv.ProcesarCalificacionFinal(matriculaId);

                if (res == null) return ApiResponse<CalificacionDTO>.ErrorResponse("Error");

                return ApiResponse<CalificacionDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<CalificacionDTO>.ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        // GET api/calificacion/activar/procesar
        [HttpGet("activar/procesar/{matriculaId}")]
        public ApiResponse<long> PostCalculateCuestion(long matriculaId)
        {
            try
            {
                var res = _serv.ValidarEstadoProcesamiento(matriculaId);

                if (res == null) return ApiResponse<long>.ErrorResponse("Error");

                return ApiResponse<long>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<long>.ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
