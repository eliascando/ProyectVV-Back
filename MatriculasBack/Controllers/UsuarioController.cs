using Infraestructure.Persistence.Context;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;
using Application.Services;
using Domain.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace MatriculasBack.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioServ;
        public UsuarioController(UsuarioService service)
        {
            _usuarioServ = service;
        }

        [HttpGet("todos")]
        [Authorize(Policy = "AdminOnly")]
        public ApiResponse<List<NewUserDTO>> GetAll()
        {
            try
            {
                var user = _usuarioServ.ObtenerTodos();

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo obtener", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("/api/docentes")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<List<NewUserDTO>> GetDocentes()
        {
            try
            {
                var user = _usuarioServ.ObtenerDocentes();

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo obtener", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("/api/estudiantes")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<List<NewUserDTO>> GetEstudiantes()
        {
            try
            {
                var user = _usuarioServ.ObtenerEstudiantes();

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo obtener", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("/api/estudiante/curso/{id}")]
        [Authorize(Policy = "DocenteOnly")]
        public ApiResponse<List<NewUserDTO>> GetEstudianteByCourseId(long id)
        {
            try
            {
                var user = _usuarioServ.ObtenerEstudiantesPorCurso(id);

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");

            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("curso/{id}")]
        [Authorize(Policy = "DocenteOnly")]
        public ApiResponse<List<NewUserDTO>> GetAllByCourseId(long id)
        {
            try
            {
                var user = _usuarioServ.ObtenerTodosPorCursoId(id);

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");

            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("/api/docente/curso/{id}")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<List<NewUserDTO>> GetDocenteByCourseId(long id)
        {
            try
            {
                var user = _usuarioServ.ObtenerEstudiantesPorCurso(id);

                if (user == null) return ApiResponse<List<NewUserDTO>>.ErrorResponse("No se pudo obtener", HttpStatusCode.Conflict);

                return ApiResponse<List<NewUserDTO>>.SuccessResponse(user, "Registrado exitosamente!");

            }
            catch (Exception ex)
            {
                return ApiResponse<List<NewUserDTO>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }


        // POST api/usuario/registrar   --Para administrador
        [HttpPost("registrar")]
        [AllowAnonymous]
        //[Authorize(Policy = "AdminOnly")]
        public ApiResponse<NewUserDTO> Post([FromBody] UsuarioRegistroDTO newUser)
        {
            try
            {
                var user = _usuarioServ.Register(newUser);

                if (user == null) return ApiResponse<NewUserDTO>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);
            
                return ApiResponse<NewUserDTO>.SuccessResponse(user, "Registrado exitosamente!");

            } catch (Exception ex) 
            {
                return ApiResponse<NewUserDTO>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("/api/estudiante/registrar")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<NewUserDTO> PostEstudiante([FromBody] UsuarioRegistroDTO newStudent)
        {
            try
            {
                long ESTUDIANTE_ROLE_ID = 2;
                newStudent.RoleId = ESTUDIANTE_ROLE_ID;

                var user = _usuarioServ.Register(newStudent);

                if (user == null) return ApiResponse<NewUserDTO>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);

                return ApiResponse<NewUserDTO>.SuccessResponse(user, "Registrado exitosamente!");

            }
            catch (Exception ex)
            {
                return ApiResponse<NewUserDTO>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("/api/docente/registrar")]
        [Authorize(Policy = "SecretaryOnly")]
        public ApiResponse<NewUserDTO> PostDocente([FromBody] UsuarioRegistroDTO newDocente)
        {
            try
            {
                long DOCENTE_ROLE_ID = 1;
                newDocente.RoleId = DOCENTE_ROLE_ID;

                var user = _usuarioServ.Register(newDocente);

                if (user == null) return ApiResponse<NewUserDTO>.ErrorResponse("No se pudo registrar", HttpStatusCode.Conflict);

                return ApiResponse<NewUserDTO>.SuccessResponse(user, "Registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<NewUserDTO>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("inactivar/{id}")]
        public ApiResponse<bool> InactivateUser(long id)
        {
            try
            {
                var res = _usuarioServ.Inactivate(id);
                
                if(res) return ApiResponse<bool>.SuccessResponse(true);

                return ApiResponse<bool>.ErrorResponse("Error al inactivar!");
            }
            catch(Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("actualizar/{id}")]
        public ApiResponse<NewUserDTO> Actualizar(long id, [FromBody] UpdateUser usuario)
        {
            try
            {
                var res = _usuarioServ.UpdateInfo(id, usuario);

                if (res == null) return ApiResponse<NewUserDTO>.ErrorResponse("No se pudo actualizar", HttpStatusCode.Conflict);

                return ApiResponse<NewUserDTO>.SuccessResponse(res, "Actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                return ApiResponse<NewUserDTO>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

    }
}
