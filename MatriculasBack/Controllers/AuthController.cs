using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MatriculasBack.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // POST api/login
        [HttpPost]
        [AllowAnonymous]
        public ApiResponse<LoginResultDTO> Login([FromBody] LoginDTO login)
        {
            try
            {
                var res = _authService.Login(login);

                if (res != null)
                {
                    return ApiResponse<LoginResultDTO>.SuccessResponse(res, "Inicio de sesión exitoso");
                } else
                {
                    return ApiResponse<LoginResultDTO>.ErrorResponse("Usuario no encontrado");
                }
            }
            catch (Exception ex) 
            {
                return ApiResponse<LoginResultDTO>.ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }

        }
    }
}
