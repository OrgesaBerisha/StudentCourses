using Microsoft.EntityFrameworkCore;
using StudentCourses.Data;
using StudentCourses.Data.DTO;
using StudentCourses.Data.Interface;
using StudentCourses.Models;

namespace StudentCourses.Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;

        // Hiq UserManager nga constructor
        public CourseService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Professor) // Include professor per UserName
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ProfessorId = c.ProfessorId,
                    ProfessorName = c.Professor.UserName,
                    ImageUrl = c.ImageUrl
                }).ToListAsync();
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Professor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return null;

            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ProfessorId = course.ProfessorId,
                ProfessorName = course.Professor.UserName,
                ImageUrl = course.ImageUrl
            };
        }

        public async Task<CourseDTO> CreateCourseAsync(CourseDTO courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                ProfessorId = courseDto.ProfessorId,
                ImageUrl = courseDto.ImageUrl
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            courseDto.Id = course.Id;
            return courseDto;
        }

        public async Task<bool> UpdateCourseAsync(int id, CourseDTO courseDto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            course.Name = courseDto.Name;
            course.Description = courseDto.Description;
            course.ProfessorId = courseDto.ProfessorId;
            course.ImageUrl = courseDto.ImageUrl;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
