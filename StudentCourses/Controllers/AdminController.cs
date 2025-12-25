using Microsoft.AspNetCore.Mvc;
using StudentCourses.Data.DTO;
using StudentCourses.Data.Interface;
using Microsoft.AspNetCore.Authorization;


namespace StudentCourses.Controllers
{
    [ApiController]
    [Route("api/admins")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult CreateAdmin(AdminDTO dto)
        {
            _adminService.CreateAdmin(dto);
            return Ok("Admin created successfully");
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            return Ok(_adminService.GetAdmins());
        }


    }
}
