using StudentCourses.Data.DTO;

namespace StudentCourses.Data.Interface
{
    public interface IAuthService
    {
        string? Login(LoginDTO dto);
        bool Register(RegisterDTO dto);
    }
}
