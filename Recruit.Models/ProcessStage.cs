using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class ProcessStage
    {
        [Key]
        public Int64 id { get; set; }

      
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Code is invalid")]
        public string code { get; set; }

       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Stage is invalid")]
        public string stage { get; set; }

    }
}
