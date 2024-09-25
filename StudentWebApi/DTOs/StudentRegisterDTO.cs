using Student.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentWebApi.DTOs
{
    
    public class StudentRegisterDTO
    {
   
        public List<StudentHobbiesDTO> Hobbies {get; set;} = new();
        public int StudentID { get; set;}

        [Required(ErrorMessage = "First name is Required")]

        [MaxLength(30, ErrorMessage = "First name cannot exceeds 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(30, ErrorMessage = "Last name cannot exceed 30 characters")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Date of birth is required.")]
        //[DataType(DataType.Date, ErrorMessage = "Date of birth must be a valid date.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email ID is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(50, ErrorMessage = "Email ID cannot exceed 50 characters.")]
        public string EmailD { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Range(1000000000, 9999999999, ErrorMessage = "Mobile number must be a valid 10-digit number.")]
        public int MobileNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [MaxLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public Gender Gender { get; set; }
        //public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(30, ErrorMessage = "City cannot exceed 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pincode is required.")]
        [Range(100000, 999999, ErrorMessage = "Pincode must be a valid 6-digit number.")]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [MaxLength(30, ErrorMessage = "State cannot exceed 30 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; }

        

        //courses
        public int CourseID { get; set; }

        //[MaxLength(50)]
        //public string CourseName { get; set; }


        //qualifications 

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
    }

}   
