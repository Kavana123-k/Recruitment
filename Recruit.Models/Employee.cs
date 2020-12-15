using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class Employee
    {
        [Key]
        public Int64 id { get; set; }
        public string code { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Employee Name is invalid")]
        public string name { get; set; }
    }
}
