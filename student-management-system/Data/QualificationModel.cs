using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Data
{
    public class QualificationModel
    {
        [Key]
        public int ID { get; set; }

        public int StudentID { get; set; }


        [MaxLength(50)]
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
