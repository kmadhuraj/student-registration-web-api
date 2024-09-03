using Student.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.DTOs
{
    public class QualificationDTO
    {
        [ForeignKey(nameof(StudentDetails))]
        public int StudentID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Class X Board is required.")]
        public string ClassXBoard { get; set; }

        [Range(0, 100, ErrorMessage = "Class X Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal ClassXPercentage { get; set; }

        [Range(1900, 2100, ErrorMessage = "Class X Year of Passing must be between 1900 and 2100.")]
        public int ClassXYearOfPassing { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Class XI Board is required.")]
        public string ClassX11Board { get; set; }

        [Range(0, 100, ErrorMessage = "Class XI Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Class11Percentage { get; set; }

        [Range(1900, 2100, ErrorMessage = "Class XI Year of Passing must be between 1900 and 2100.")]
        public int ClassX11YearOfPassing { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Graduation Board is required.")]
        public string GraduationBoard { get; set; }

        [Range(0, 100, ErrorMessage = "Graduation Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal GraduationPercentage { get; set; }

        [Range(1900, 2100, ErrorMessage = "Graduation Year of Passing must be between 1900 and 2100.")]
        public int GraduationYearOfPasssing { get; set; }

        [MaxLength(50)]
        public string MastersBoard { get; set; }

        [Range(0, 100, ErrorMessage = "Masters Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal MastersPercentage { get; set; }

        [Range(1900, 2100, ErrorMessage = "Masters Year of Passing must be between 1900 and 2100.")]
        public int MastersYearOfPasssing { get; set; }
    }
}
