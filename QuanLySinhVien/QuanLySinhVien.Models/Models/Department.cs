using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required,StringLength(50,MinimumLength = 10,ErrorMessage = "Name of department must be not null and between 10 and 50"),Display(Name = "Department")]
        public string Name { get; set; }
        [DataType(DataType.Currency),Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
