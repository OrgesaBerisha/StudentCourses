using StudentCourses.Data.DTO;
using StudentCourses.Data;
using System;
using StudentCourses.Data.Interface;
using StudentCourses.Models;
using BCrypt.Net;


namespace StudentCourses.Services
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _context;

        public AdminService(DataContext context)
        {
            _context = context;
        }

        public void CreateAdmin(AdminDTO dto)
        {
            var admin = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Admin"
            };

            _context.Users.Add(admin);
            _context.SaveChanges();
        }

        public List<User> GetAdmins()
        {
            return _context.Users
                .Where(x => x.Role == "Admin")
                .ToList();
        }
    }
}
