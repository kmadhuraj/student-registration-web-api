using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentRegister
    {
        public StudentDetails StudentDetails = new();
        public List<Courses> Courses = new();
        public List<Hobbies> Hobbies = new();
    }
}
