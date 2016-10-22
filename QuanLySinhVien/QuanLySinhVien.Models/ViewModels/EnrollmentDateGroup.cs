using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true),Display(Name = "Enrollment date group")]
        public DateTime EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
    }
}
