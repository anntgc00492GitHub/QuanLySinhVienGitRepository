using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Models.Abstract;

namespace QuanLySinhVien.Models.Models
{
    public class Instructor:Person
    {
        [DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true),Display(Name = "Hire date")]
        public DateTime HireDate { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
