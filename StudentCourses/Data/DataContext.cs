using Microsoft.EntityFrameworkCore;
using StudentCourses.Models;
using System.Data;

namespace StudentCourses.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //lidhjet bohen qetu one to many
        {
            // base.OnModelCreating(modelBuilder) 

        }

    }
}



