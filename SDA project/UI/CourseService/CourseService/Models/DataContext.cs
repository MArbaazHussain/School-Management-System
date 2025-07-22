using Microsoft.EntityFrameworkCore;

namespace CourseService.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
 
    }

 }
