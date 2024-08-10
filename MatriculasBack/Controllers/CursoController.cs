using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculasBack.Controllers
{
    [Route("api/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoServ;

        public CursoController(CursoService cursoServ)
        {
            _cursoServ = cursoServ;
        }

        // GET api/curso/todos
        [HttpGet("todos")]
        //[Authorize(Policy = "SecretaryOnly")]
        [Authorize(Policy = "AdminOnly")]
        public ApiResponse<List<Curso>> GetAll()
        {
            try
            {
                var list = _cursoServ.ObtenerTodos();

                return ApiResponse<List<Curso>>.SuccessResponse(list);
            }
            catch(Exception ex)
            {
                return ApiResponse<List<Curso>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GET api/cursos/docente/{id}
        [HttpGet("/api/cursos/docente/{id}")]
        [Authorize(Policy = "DocenteOnly")]
        public ApiResponse<List<CursoDTO>> GetAllByDocenteDto(long id)
        {
            try
            {
                var list = _cursoServ.ObtenerCursosPorDocente(id);

                return ApiResponse<List<CursoDTO>>.SuccessResponse(list);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CursoDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GET api/curso/todos
        [HttpGet("/api/cursos")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<List<CursoDTO>> GetAllDto()
        {
            try
            {
                var list = _cursoServ.ObtenerTodosDto();

                return ApiResponse<List<CursoDTO>>.SuccessResponse(list);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CursoDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // POST api/curso/registrar
        [HttpPost("registrar")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<Curso> Registrar([FromBody] NewCursoDTO newCurso)
        {
            try
            {
                var res = _cursoServ.Register(newCurso);

                if (res == null) return ApiResponse<Curso>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);

                return ApiResponse<Curso>.SuccessResponse(res);
            }
            catch(Exception ex)
            {
                return ApiResponse<Curso>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }

        }

        [HttpPut("actualizar/{id}")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<Curso> Actualizar(long id, [FromBody] UpdateCursoDTO update)
        {
            try
            {
                var res = _cursoServ.UpdateInfo(id, update);

                if (res == null) return ApiResponse<Curso>.ErrorResponse("No se pudo actualizar", HttpStatusCode.Conflict);

                return ApiResponse<Curso>.SuccessResponse(res, "Actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<Curso>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("inactivar/{id}")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<bool> InactivateUser(long id)
        {
            try
            {
                var res = _cursoServ.Inactivate(id);

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
