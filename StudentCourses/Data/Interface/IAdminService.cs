using StudentCourses.Data.DTO;
using StudentCourses.Models;

namespace StudentCourses.Data.Interface
{
    public interface IAdminService
    {
        void CreateAdmin(AdminDTO dto);
        List<User> GetAdmins();
    }
}
