using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class tbl_interview_round_statuses
    {   
        [Key]
        public Int64 id { get; set; }
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Status is invalid")]
        public string status { get; set; }
    }
}

