using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class Qualifications
    {
        [Key]
        public int ID { get; set; }

        public int StudentID { get; set; }

        [ForeignKey(nameof(StudentID))]
        public StudentDetails Student { get; set; }  

        [MaxLength(50)]
        public string ClassXBoard { get; set; }

        [Column(TypeName ="decimal(5,2)")]
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
