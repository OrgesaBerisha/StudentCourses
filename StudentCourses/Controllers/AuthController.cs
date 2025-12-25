using Microsoft.AspNetCore.Mvc;
using StudentCourses.Data.DTO;
using StudentCourses.Data.Interface;

namespace StudentCourses.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var token = _authService.Login(dto);

            if (token == null)
                return Unauthorized("Email or password incorrect");

            return Ok(new { token });


        }

    }
}
