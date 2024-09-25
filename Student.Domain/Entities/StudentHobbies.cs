using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentHobbies
    {
        [Key]
        public int ID { get; set; }

        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public StudentDetails StudentDetail { get; set; }

       
        [MaxLength(50)]
        public string Hobbie { get; set; }
    }
}
