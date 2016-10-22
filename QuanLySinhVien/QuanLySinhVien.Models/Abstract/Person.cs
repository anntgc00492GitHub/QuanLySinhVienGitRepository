using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Models.Abstract
{
    public abstract class Person:IPerson
    {
        [Key]
        public int PersonID { get; set; }
        [Required,StringLength(10,MinimumLength = 3,ErrorMessage = "Firstname must be between 3 and 10 characters"),Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required,StringLength(10,MinimumLength = 3,ErrorMessage = "Last Name must be between 3 and 10 characters"),Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
