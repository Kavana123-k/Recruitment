using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models 
{ 
    public class tbl_vacancies
    {
       [Key]
        public string code { get; set; }

        [StringLength(15)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "name is not valid")]
        public string name { get; set; }

        public Int64 vacancy { get; set; }
    }
}
