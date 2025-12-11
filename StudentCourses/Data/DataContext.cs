using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StudentCourses.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //lidhjet bohen qetu one to many
        {
            // base.OnModelCreating(modelBuilder) 

        }

    }
}
