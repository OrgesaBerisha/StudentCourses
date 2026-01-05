using StudentCourses.Data.DTO;
using StudentCourses.Models;

namespace StudentCourses.Data.Interface
{
    public interface IUserService
    {
        void CreateUser(UserDTO dto);
        User? GetUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
    }
}
