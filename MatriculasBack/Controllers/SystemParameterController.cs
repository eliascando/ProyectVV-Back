using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculasBack.Controllers
{
    [Route("api/parameter")]
    [ApiController]
    public class SystemParameterController : ControllerBase
    {
        private readonly SystemParameterService _paramServ;

        public SystemParameterController(SystemParameterService paramServ)
        {
            _paramServ = paramServ;
        }

        // GET: api/parameter/todos
        [HttpGet("todos")]
        [Authorize(Policy = "AdminOnly")]
        public ApiResponse<List<SystemParameter>> GetAll()
        {
            try
            {
                var list = _paramServ.ObtenerTodos();

                return ApiResponse<List<SystemParameter>>.SuccessResponse(list);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<SystemParameter>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ApiResponse<SystemParameter> GetById(long id)
        {
            try
            {
                var sp = _paramServ.ObtenerPorId(id);

                return ApiResponse<SystemParameter>.SuccessResponse(sp);
            }
            catch (Exception ex)
            {
                return ApiResponse<SystemParameter>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        //
        [HttpGet("/api/calificacion/dropdowns/{idEstudiante}/{idCurso}")]
        public ApiResponse<List<SystemParameter>> GetByIdStudentAnCourse(long idEstudiante, long idCurso)
        {
            try
            {
                var sp = _paramServ.ObtenerDropDownsPorEstudiante(idEstudiante, idCurso);

                return ApiResponse<List<SystemParameter>>.SuccessResponse(sp);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<SystemParameter>>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
