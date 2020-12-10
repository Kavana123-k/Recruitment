using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class Candidate
    {

        [Key]
        public Int64 id { get; set; }


        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Firstname invalid")]
        public String first_name { get; set; }


        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lastname is invalid")]
        public String last_name { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is invalid")]
        public String email { get; set; }


        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is invalid")]
        public String phone { get; set; }

        [ForeignKey("source_code")]
        [Required(ErrorMessage = "Enter the source")]
        public String source_code { get; set; }
        public String source_name { get; set; }
        [ForeignKey("referral_id")]

        public String referral_id { get; set; }
        public String emp_ref { get; set; }

        [Required(ErrorMessage = "Total Experience is invalid")]
        public Int64 total_experience { get; set; }

        [Required(ErrorMessage = "Relevant Experience is invalid")]
        public Int64 relevant_experience { get; set; }

        [StringLength(30)]
        [DataType(DataType.Text)]

        public String current_employer { get; set; }
        [StringLength(25)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Current Designation is invalid")]
        public String current_designation { get; set; }
        [ForeignKey("position_applied_code")]
        [Required(ErrorMessage = "Position Applied  is invalid")]
        public String position_applied_code { get; set; }
        public String position { get; set; }

        [Required(ErrorMessage = "Current Ctc is invalid")]
        public Int64 current_ctc { get; set; }

        [Required(ErrorMessage = "Expected Ctc is invalid")]
        public Int64 expected_ctc { get; set; }

        [StringLength(150)]
        [DataType(DataType.Text)]
        public String reason_for_change { get; set; }

        [Required(ErrorMessage = "Notice Period is invalid")]
        public Int64 notice_period { get; set; }

        [Required(ErrorMessage = "is serving notice is invalid")]
        public bool is_serving_notice { get; set; }


        [Display(Name = "Last working day")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> last_working_day { get; set; }


        [StringLength(30)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Current Locations is invalid")]
        public String current_location { get; set; }


        [ForeignKey("process_stage_id")]
        [Required(ErrorMessage = "Process Stage is invalid")]
        public Int64 process_stage_id { get; set; }
        public String stage { get; set; }

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
        public Nullable<System.DateTime> process_end_date { get; set; }

        [ForeignKey("interview_status_id")]
        [Required(ErrorMessage = "Interview Status is invalid")]
        public Int64 interview_status_id { get; set; }
        public String status { get; set; }


        [ForeignKey("resume_owner_id")]
        [Required(ErrorMessage = "Resume Owner id is invalid")]
        public Int64 resume_owner_id { get; set; }
        public String owner { get; set; }


        [ForeignKey("owner_for_reminder_id")]
        [Required(ErrorMessage = "Owner For Reminder is invalid")]
        public Int64 owner_for_reminder_id { get; set; }
        public String remind { get; set; }


        [StringLength(150)]
        [DataType(DataType.Text)]
        public String comments { get; set; }


        [Display(Name = "Date of join")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_joining { get; set; }


        [StringLength(150)]
        [DataType(DataType.Text)]
        public String notes { get; set; }


        [StringLength(50)]
        [DataType(DataType.Text)]
        public String links_for_interview { get; set; }


    }

}
