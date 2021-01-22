using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class InterviewDetail
    {
        [Key]
        public Int64 id { get; set; }
        [ForeignKey("candidate_id")]
        [Required(ErrorMessage = "Candidate id invalid")]

        public Int64 candidate_id { get; set; }

        [Required(ErrorMessage = "Please choose correct Interview Stage")]
        [Display(Name = "Interview Stage")]
        
        public String interview_stage_id { get; set; }
        public String first_name { get; set; }
        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview Start date")]
        [DataType(DataType.DateTime)]
        public DateTime start_date_time { get; set; }

        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview end date")]
        [DataType(DataType.DateTime)]
        public DateTime end_date_time { get; set; }

        [ForeignKey("status_id")]
        [Required(ErrorMessage = "Interview Round Status invalid")]
        public Int64 status_id { get; set; }
        public string status { get; set; }

        [StringLength(150)]
        [DataType(DataType.Text)]
        public string reason { get; set; }


        //custom attribute

        //[ForeignKey("candidate_id")]
        //[Required(ErrorMessage = "Enter the Canidate Id")]
        //public Int64 candidate_id { get; set; }


        #region Custom Attributes

        /// <summary>
        /// custom attribute to store the interviewer details
        /// </summary>
        [ForeignKey("employee_id")]
        [Required(ErrorMessage = "Enter the Employee Id")]
        // public List<Int64> employee_id { get; set; }
        public Int64 employee_id { get; set; }
        public string emp_name
        {
            get; set;
        }
        public List<string> employee_name { get; set; }

        [NotMapped]
        public List<Interviewer> Interviewer { get; set; }


        //[ForeignKey("interview_id")]
        //[Required(ErrorMessage = "Enter the Interview Id")]
        //public Int64 interview_id { get; set; }

        #endregion


    }
}
