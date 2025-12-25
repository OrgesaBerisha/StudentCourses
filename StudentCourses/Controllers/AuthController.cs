using Microsoft.AspNetCore.Mvc;
using StudentCourses.Data.Interface;

namespace StudentCourses.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



    }
}
