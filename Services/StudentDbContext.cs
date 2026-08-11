using StudentTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentTracker.Services
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }

}
