using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjects
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? YearEstablish { get; set; }

        public ICollection<Student> Students { get;set; }=new List<Student>(); 
    }
}
