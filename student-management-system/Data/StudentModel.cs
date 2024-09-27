using student_management_system.Pages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Data
{
    public class StudentModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        //[DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string EmailD { get; set; }
        public int MobileNumber { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }
        public int Pincode { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [ForeignKey(nameof(Courses))]
        public int CourseID { get; set; }
    }
}
