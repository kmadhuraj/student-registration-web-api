using Student.Application.Abstractions;
using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public UnitOfWorkRepository(ApplicationDbContext context)
        {

            _context = context;
            CourseRepository = new EntityFrameworkRepository<Courses>(context);
            StudentDetailsRepository=new EntityFrameworkRepository<StudentDetails>(context);
            StudentHobbiesRepository=new EntityFrameworkRepository<StudentHobbies>(context);
            QualificationsRepository=new EntityFrameworkRepository<Qualifications>(context);
            HobbiesRepository=new EntityFrameworkRepository<Hobbies>(context);
            //StudentRegisterRepository = new EntityFrameworkRepository<StudentRegister>(context);

        }
        public IRepository<Courses> CourseRepository { get; set; }
        public IRepository<StudentDetails> StudentDetailsRepository {  get; set; }
        public IRepository<StudentHobbies> StudentHobbiesRepository { get;  set; }
        public IRepository<Qualifications> QualificationsRepository { get;  set; }
        public IRepository<Hobbies> HobbiesRepository { get;  set; }

        //public IRepository<StudentRegister> StudentRegisterRepository { get; set; }

    }
    
}
