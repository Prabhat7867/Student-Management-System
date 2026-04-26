using Microsoft.EntityFrameworkCore;

namespace SMS_API.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options): base(options) { }

        public DbSet<Student> Students { get; set; }
    }

    
}
