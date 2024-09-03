using Student.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Infrastructure;
using Student.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Student.Infrastructure.Repositories
{
    public class StudentRepository:IStudentInterface
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDetails> AddStudent(StudentDetails student)
        {
            _context.StudentDetails.Add(student);
            await _context.SaveChangesAsync();
            return student;
            
        }   

        public async Task<StudentDetails> DeleteStudent(int studentId)
        {
            var student = _context.StudentDetails.FirstOrDefault(x=>x.ID == studentId);
            if (student != null)
            {
                _context.StudentDetails.Remove(student);
                await _context.SaveChangesAsync();
                
            }
            return student;
        }

        public async Task<ICollection<StudentDetails>> GetAllDetails()
        {
            return await _context.StudentDetails.ToListAsync();
          
        }

        public async Task<StudentDetails> GetStudentById(int studentId)
        {
            return await _context.StudentDetails.FirstOrDefaultAsync(x=>x.ID==studentId);
            
        }

        public async Task<StudentDetails> UpdateStudent(StudentDetails student)
        {
            if(student != null)
            {
                _context.StudentDetails.Update(student);
                await _context.SaveChangesAsync();

            }
            return null;
           
        }
    }


}
