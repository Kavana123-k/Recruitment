using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class ProcessStages
    {
        [Key]
        public Int64 id { get; set; }

        [StringLength(15)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Code is invalid")]
        public string code { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Stage is invalid")]
        public string stage { get; set; }

    }
}
