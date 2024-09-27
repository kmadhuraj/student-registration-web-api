using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Data
{
    public class StudentDetails
    {
        public int ID { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string EmailD { get; set; }
        public int MobileNumber { get; set; }

        public int Gender { get; set; }
        
        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }
        public int Pincode { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        
        //quallifications
        public string ClassXBoard { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal ClassXPercentage { get; set; }
        public int ClassXYearOfPassing { get; set; }

        [MaxLength(50)]
        public string ClassX11Board { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Class11Percentage { get; set; }

        public int ClassX11YearOfPassing { get; set; }

        [MaxLength(50)]
        public string GraduationBoard { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal GraduationPercentage { get; set; }
        public int GraduationYearOfPasssing { get; set; }

        [MaxLength(50)]
        public string MastersBoard { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal MastersPercentage { get; set; }

        public int MastersYearOfPasssing { get; set; }

        //hobies
       public List<StudentHobbies> Hobbies { get; set; } = new();

        
        //courses
       public int CourseID { get; set; }
        
    }
}
