using Application.Services;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculasBack.Controllers
{
    [Route("api/matricula")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaService _matrServ;

        public MatriculaController(MatriculaService matrServ)
        {
            _matrServ = matrServ;
        }

        // POST api/matricula/docente
        [HttpGet("todos")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<List<MatriculaDTO>> GetAll()
        {
            try
            {
                var list = _matrServ.ObtenerTodosDto();

                return ApiResponse<List<MatriculaDTO>>.SuccessResponse(list);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<MatriculaDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // POST api/matricula/docente
        [HttpPost("docente")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<Matricula> MatricularDocente([FromBody] NewMatriculaDTO newMatr)
        {
            try
            {
                long DOCENTE_TYPE_ID = 9;
                newMatr.TypeId = DOCENTE_TYPE_ID;

                var res = _matrServ.Register(newMatr);

                if(res == null) return ApiResponse<Matricula>.ErrorResponse("Error al registrar matricula", HttpStatusCode.Conflict);

                return ApiResponse<Matricula>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<Matricula>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // POST api/matricula/estudiante
        [HttpPost("estudiante")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<Matricula> MatricularEstudiante([FromBody] NewMatriculaDTO newMatr)
        {
            try
            {
                long ESTUDIANTE_TYPE_ID = 10;
                newMatr.TypeId = ESTUDIANTE_TYPE_ID;

                var res = _matrServ.Register(newMatr);

                if (res == null) return ApiResponse<Matricula>.ErrorResponse("Error al registrar matricula", HttpStatusCode.Conflict);

                return ApiResponse<Matricula>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<Matricula>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/matricula/eliminar
        [HttpDelete("eliminar/{id}")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<bool> Delete(int id)
        {
            try
            {
                var res = _matrServ.Inactivate(id);

                if (res) return ApiResponse<bool>.SuccessResponse(true);

                return ApiResponse<bool>.ErrorResponse("Error al inactivar!");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
