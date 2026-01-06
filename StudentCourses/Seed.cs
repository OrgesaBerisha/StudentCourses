using Microsoft.AspNetCore.Identity;
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

        public static void SeedCourses(DataContext context)
        {
            if (!context.Courses.Any())
            {
                // Vendos një Id ekzistues të profesorit manual ose krijo më pas userin në Program.cs
                string professorId = "1"; // <-- ky duhet të jetë Id i userit që ekziston në DB

                context.Courses.AddRange(
                    new Course { Name = "Mathematics", Description = "Math course", ProfessorId = professorId, ImageUrl = "/images/math.jpg" },
                    new Course { Name = "Physics", Description = "Physics course", ProfessorId = professorId, ImageUrl = "/images/physics.jpg" },
                    new Course { Name = "Chemistry", Description = "Chemistry course", ProfessorId = professorId, ImageUrl = "/images/chemistry.jpg" },
                    new Course { Name = "Biology", Description = "Biology course", ProfessorId = professorId, ImageUrl = "/images/biology.jpg" },
                    new Course { Name = "History", Description = "History course", ProfessorId = professorId, ImageUrl = "/images/history.jpg" },
                    new Course { Name = "Geography", Description = "Geography course", ProfessorId = professorId, ImageUrl = "/images/geography.jpg" },
                    new Course { Name = "English", Description = "English course", ProfessorId = professorId, ImageUrl = "/images/english.jpg" },
                    new Course { Name = "Computer Science", Description = "CS course", ProfessorId = professorId, ImageUrl = "/images/cs.jpg" },
                    new Course { Name = "Art", Description = "Art course", ProfessorId = professorId, ImageUrl = "/images/art.jpg" },
                    new Course { Name = "Music", Description = "Music course", ProfessorId = professorId, ImageUrl = "/images/music.jpg" }
                );
                context.SaveChanges();
            }
        }









    }
}

