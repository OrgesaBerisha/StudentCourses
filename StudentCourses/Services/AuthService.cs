using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentCourses.Data;
using StudentCourses.Data.DTO;
using StudentCourses.Data.Interface;
using StudentCourses.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentCourses.Data.Service
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AuthService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string? Login(LoginDTO dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}




//using Microsoft.IdentityModel.Tokens;
//using StudentCourses.Data;
//using StudentCourses.Data.DTO;
//using StudentCourses.Data.Interface;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace StudentCourses.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly DataContext _context;
//        private readonly IConfiguration _config;


//        public AuthService(DataContext context, IConfiguration config)
//        {
//            _context = context;
//            _config = config;
//        }

//        public string? Login(LoginDTO dto)
//        {
//            var user = _context.Users
//                .FirstOrDefault(u => u.Email == dto.Email);

//            if (user == null)
//                return null;

//            bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

//            if (!passwordValid)
//                return null;

//            var claims = new[]
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim(ClaimTypes.Role, user.Role)
//            };

//            var key = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
//            );

//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _config["Jwt:Issuer"],
//                audience: _config["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(
//                    double.Parse(_config["Jwt:DurationInMinutes"])
//                ),
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//    }
//}
