using StudentCourses.Data;
using StudentCourses.Models;

namespace StudentCourses
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            if (!_context.Users.Any(u => u.Role == "Admin"))
            {
                var admin = new User
                {
                    FullName = "Admin",
                    Email = "admin@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Role = "Admin"
                };
                _context.Users.Add(admin);
            }

            if (!_context.Users.Any(u => u.Role == "Professor"))
            {
                var prof = new User
                {
                    FullName = "Profesori",
                    Email = "prof@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("profesor123"),
                    Role = "Professor"
                };
                _context.Users.Add(prof);
            }

            if (!_context.Users.Any(u => u.Role == "Student"))
            {
                var student = new User
                {
                    FullName = "Studenti",
                    Email = "student@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("student123"),
                    Role = "Student"
                };
                _context.Users.Add(student);
            }

            _context.SaveChanges();
        }
    }
}

