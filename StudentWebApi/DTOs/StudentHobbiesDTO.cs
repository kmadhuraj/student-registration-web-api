using Student.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.DTOs
{
    public class StudentHobbiesDTO
    {

        [ForeignKey(nameof(StudentDetails))]
        public int StudentID { get; set; }

        // Navigation property (commented out)
        // public StudentDetails Student { get; set; }

        [Required(ErrorMessage = "Hobbie is required.")]
        [MaxLength(50, ErrorMessage = "Hobbie cannot exceed 50 characters.")]
        public string Hobbie { get; set; }

    }
}
