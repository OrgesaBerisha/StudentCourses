using StudentCourses.Data;

namespace StudentCourses
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
    }
}
