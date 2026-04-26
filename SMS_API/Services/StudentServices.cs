using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using SMS_API.Data;
using System.Diagnostics;

namespace SMS_API.Services
{
    public class StudentServices
    {
        private readonly StudentDBContext context;
        public StudentServices(StudentDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Student>> GetStudents() 
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentbyId(int id)
        {
            return await context.Students.SingleOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Student> AddStudent(Student std)
        {
            await context.AddAsync(std);
            await context.SaveChangesAsync();
            return std;
        }

        public async Task<Student> UpdateStudent(Student std)
        {
            var student = await context.Students.FindAsync(std.Id);
            if (student != null)
            {
                context.Entry(student).State = EntityState.Detached;
                context.Entry(std).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            else { return null; }

            return std;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await  context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }

            return student; 
        }

    }
}
