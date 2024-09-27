using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    
    public class StudentDetails
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string EmailD { get; set; }
        public int MobileNumber { get; set; }

        //public string Gender { get; set; }
        public  int Gender { get; set; }

        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }
        public int Pincode { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public int CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Courses Courses { get; set; }


        //to add navigation to the courses
        //public Courses Courses { get; set; }
    }
}
