using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Courses> CourseRepository { get; set;}
        IRepository<StudentDetails> StudentDetailsRepository { get; set;}
        IRepository<StudentHobbies> StudentHobbiesRepository { get; set;}
        IRepository<Qualifications> QualificationsRepository { get; set;}
        IRepository<Hobbies> HobbiesRepository { get; set;}

        //IRepository<StudentRegister> StudentRegisterRepository { get; set;}
    }
}
