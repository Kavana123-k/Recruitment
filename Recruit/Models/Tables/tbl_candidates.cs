using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class tbl_candidates
    {

        [Key]
        public Int64 id { get; set; }


        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "first name invalid")]
         public String first_name { get; set; }


        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "last_name is invalid")]
        public String last_name { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email is invalid")]
        public String email { get; set; }


        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "phone is invalid")]
        public String phone { get; set; }
        
        [ForeignKey("source_code")]
        [Required(ErrorMessage = "source_code is invalid")]
        public String source_code { get; set; }
        [ForeignKey("referral_id")]
       
        public String referral_id { get; set; }

        [Required(ErrorMessage = "total_experience is invalid")]
        public Int64 total_experience { get; set; }

        [Required(ErrorMessage = "relevant_experience is invalid")]
        public Int64 relevant_experience { get; set; }
       
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "current_employer is invalid")]
        public String current_employer { get; set; }
        [StringLength(25)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "current_designation is invalid")]
        public String current_designation { get; set; }
        [ForeignKey("position_applied_code")]
        [Required(ErrorMessage = "position applied code is invalid")]
        public String position_applied_code { get; set; }

        [Required(ErrorMessage = "current_ctc is invalid")]
        public Int64 current_ctc { get; set; }
       
        [Required(ErrorMessage = "expected_ctc is invalid")]
        public Int64 expected_ctc { get; set; }
     
        [StringLength(150)]
        [DataType(DataType.Text)]
        public String reason_for_change { get; set; }
       
        [Required(ErrorMessage = "notice_period is invalid")]
        public Int64 notice_period { get; set; }
      
        [Required(ErrorMessage = "is_serving_notice is invalid")]
        public bool is_serving_notice { get; set; }
        
     
        [Display(Name = "Last working day")]
        [DataType(DataType.Date)]
        public DateTime last_working_day { get; set; }
       
        
        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "email is invalid")]
        public String current_location { get; set; }
       
        
        [ForeignKey("process_stage_id")]
        [Required(ErrorMessage = "process stage id is invalid")]
        public Int64 process_stage_id { get; set; }

        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview Stage date")]
        [DataType(DataType.DateTime)]
        public DateTime process_stage_date { get; set; }

        [Required(ErrorMessage = "Please choose correct date time")]
        [Display(Name = "Interview Start date")]
        [DataType(DataType.DateTime)]
       public DateTime process_start_date { get; set; }
       
       
        [Display(Name = "Interview End date")]
        [DataType(DataType.DateTime)]
        public DateTime process_end_date { get; set; }

        [ForeignKey("interview_status_id")]
        [Required(ErrorMessage = "interview status id invalid")]
        public Int64 interview_status_id { get; set; }
     
        
        [ForeignKey("resume_owner_id")]
        [Required(ErrorMessage = "resume owner id is invalid")]
        public Int64 resume_owner_id { get; set; }
     
        
        [ForeignKey("owner_for_reminder_id")]
        [Required(ErrorMessage = "owner for reminder id is invalid")]
        public Int64 owner_for_reminder_id { get; set; }
       
        
        [StringLength(150)]
        [DataType(DataType.Text)]
        public String comments { get; set; }
       
       
        [Display(Name = "Date of join")]
        [DataType(DataType.Date)]
        public DateTime date_of_joining { get; set; }
      
        
        [StringLength(150)]
        [DataType(DataType.Text)]        
        public String notes { get; set; }
       
        
        [StringLength(50)]
        [DataType(DataType.Text)]
        public String links_for_interview { get; set; }


    }

}
