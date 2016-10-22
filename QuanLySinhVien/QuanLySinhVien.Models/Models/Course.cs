using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [Required,StringLength(50,MinimumLength = 3,ErrorMessage = "Title must be not null and between 3 and 50 characters"),Display(Name = "Title")]
        public string Title { get; set; }
        [Range(10,50)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
