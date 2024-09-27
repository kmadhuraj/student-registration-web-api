using System.ComponentModel.DataAnnotations;

namespace student_management_system.Data
{
    public class StudentHobbies
    {
        //public int StudentID { get; set; }

        [Required(ErrorMessage = "Hobbie is required.")]
        [MaxLength(50, ErrorMessage = "Hobbie cannot exceed 50 characters.")]
        public string Hobbie { get; set; }

        public bool IsSelected { get; set; }
    }
}
