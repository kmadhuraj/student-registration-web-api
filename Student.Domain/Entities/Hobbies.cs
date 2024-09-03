using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class Hobbies
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Hobbie { get; set; }
    }
}
