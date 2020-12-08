using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class InterviewDetails
    {
        [ForeignKey("candidate_id")]
        [Required(ErrorMessage ="Candidate id invalid")]
        public Int64 candidate_id { get; set; }
        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview Start date")]
        [DataType(DataType.DateTime)]
        public DateTime start_date_time { get; set; }
        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview end date")]
        [DataType(DataType.DateTime)]
        public DateTime end_date_time { get; set; }
        [ForeignKey("status_id")]
        [Required(ErrorMessage ="Interview Round Status invalid")]
        public Int64 status_id { get; set; }
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string reason { get; set; }


    }
}
