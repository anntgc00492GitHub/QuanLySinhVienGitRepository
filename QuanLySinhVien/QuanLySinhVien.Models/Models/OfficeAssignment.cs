using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.Models
{
    public class OfficeAssignment
    {
        [Key,ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [Required,StringLength(10,MinimumLength = 3,ErrorMessage = "Location must be not null and beteen 3 and 10 characters"),Display(Name = "Location")]
        public string Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
