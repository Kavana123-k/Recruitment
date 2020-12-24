using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recruit.Models
{
   public class Interviewer
    {
        [Key]
        public Int64 id { get; set; }
        [ForeignKey("candidate_id")]
        [Required(ErrorMessage = "Enter the Canidate Id")]
        public Int64 candidate_id { get; set; }
        [ForeignKey("employee_id")]
        [Required(ErrorMessage = "Enter the Employee Id")]
        public Int64 employee_id { get; set; }
        [ForeignKey("interview_id")]
        [Required(ErrorMessage = "Enter the Location Id")]
        public Int64 interview_id { get; set; }
    }
}