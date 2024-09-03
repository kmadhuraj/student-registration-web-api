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

        [ForeignKey(nameof(StudentDetails))]
        public int StudentID { get; set; }

        //navigation
       // public StudentDetails Student { get;set; }


        [MaxLength(50)]
        public string Hobbie { get; set; }
    }
}
