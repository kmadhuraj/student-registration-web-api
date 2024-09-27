using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student_management_system.Data
{
   
    public class StudentRegistration
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(30, ErrorMessage = "First Name cannot exceed 30 characters.")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(30, ErrorMessage = "Last Name cannot exceed 30 characters.")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid Date of Birth.")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;



        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        [EmailAddress(ErrorMessage = "Enter a valid Email address.")]
        public string EmailD { get; set; }



        [Required(ErrorMessage = "Mobile Number is required.")]
        [Range(1000000000, 9999999999, ErrorMessage = "Enter a valid Mobile Number.")]
        public long MobileNumber { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public int Gender { get; set; } 


        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }



        [Required(ErrorMessage = "City is required.")]
        [MaxLength(30, ErrorMessage = "City name cannot exceed 30 characters.")]
        public string City { get; set; }



        [Required(ErrorMessage = "Pincode is required.")]
        [Range(100000, 999999, ErrorMessage = "Enter a valid 6-digit Pincode.")]
        public int Pincode { get; set; }



        [Required(ErrorMessage = "State is required.")]
        [MaxLength(30, ErrorMessage = "State name cannot exceed 30 characters.")]
        public string State { get; set; }


        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Country { get; set; }


        // Qualifications
        [Required(ErrorMessage = "Class X Board is required.")]
        public string ClassXBoard { get; set; }



        [Range(1, 100, ErrorMessage = "Class X Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Master percentage is required")]
        public decimal ClassXPercentage { get; set; }



        [Required(ErrorMessage = "Class X Year of Passing is required.")]
        [Range(1900, 2100, ErrorMessage = "Enter a valid Year of Passing.")]
        public int ClassXYearOfPassing { get; set; }



        [Required(ErrorMessage = "Class XI Board is required.")]
        [MaxLength(50, ErrorMessage = "Board name cannot exceed 50 characters.")]
        public string ClassX11Board { get; set; }
        


        [Range(1, 100, ErrorMessage = "Class XI Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Master percentage is required")]
        public decimal Class11Percentage { get; set; }



        [Required(ErrorMessage = "Class XI Year of Passing is required.")]
        [Range(1900, 2100, ErrorMessage = "Enter a valid Year of Passing.")]
        public int ClassX11YearOfPassing { get; set; }



        [MaxLength(50, ErrorMessage = "Graduation Board name cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Graduation Board is Required")]
        public string GraduationBoard { get; set; }



        [Range(1, 100, ErrorMessage = "Graduation Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Master percentage is required")]
        public decimal GraduationPercentage { get; set; }



        [Range(1900, 2100, ErrorMessage = "Enter a valid Graduation Year of Passing.")]
        [Required(ErrorMessage = "Graduation Year Of Passsing is Required")]
        public int GraduationYearOfPasssing { get; set; }



        [MaxLength(50, ErrorMessage = "Masters Board name cannot exceed 50 characters.")]
        [Required(ErrorMessage ="Master Board is Required")]
        public string MastersBoard { get; set; }



        [Range(1, 100, ErrorMessage = "Masters Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage ="Master percentage is required")]
        public decimal MastersPercentage { get; set; }




        [Range(1900, 2100, ErrorMessage = "Enter a valid Masters Year of Passing.")]
        [Required(ErrorMessage = "Masters Year Of Passsing  is Required")]
        public int MastersYearOfPasssing { get; set; }


        public List<StudentHobbies> Hobbies { get; set; } = new();



        // Courses
        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseID { get; set; }
    }
}






