using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class InterviewRoundStatus
    {   
        [Key]
        public Int64 id { get; set; }
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Status is invalid")]
        public string status { get; set; }
    }
}

