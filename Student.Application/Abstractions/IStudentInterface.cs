using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Domain.Entities;
namespace Student.Application.Abstractions
{
    public interface IStudentInterface
    {
        
        Task<ICollection<StudentDetails>> GetAllDetails();
  
        Task<StudentDetails>  GetStudentById(int studentId);
        Task<StudentDetails> AddStudent(StudentDetails student);
        Task<StudentDetails> UpdateStudent(StudentDetails student);
        Task<StudentDetails> DeleteStudent(int studentId);

    }
}
