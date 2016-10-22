using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.Models
{
    public class Assignment
    {
        [Key,Column(Order = 1)]
        public int InstructorID { get; set; }
        [Key,Column(Order = 2)]
        public int CourseID { get; set; }

        [ForeignKey("InstructorID")]
        public virtual Instructor Instructor { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}
