using Microsoft.EntityFrameworkCore;

namespace CRUD_Asp.Models.Student
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) :base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
