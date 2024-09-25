using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
namespace Student.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options ): base(options)
        {
            
        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Qualifications> Qualifications { get; set; }
        public DbSet<StudentHobbies> StudentHobbies { get; set; }
       
        public DbSet<StudentDetails> StudentDetails { get; set; }

        

        
    }
}
    