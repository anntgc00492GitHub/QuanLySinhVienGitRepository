using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Models.Abstract;

namespace QuanLySinhVien.Models.Models
{
    public class Student:Person
    {
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true ),Display(Name = "Enrollment date")]
        public DateTime EnrollmentDate { get; set; }

        public virtual  ICollection<Enrollment> Enrollments { get; set; }
    }
}
