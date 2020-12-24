using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recruit.Models
{
    class PreferredLocation
    {
        [Key]
        public Int64 id { get; set; }
        [ForeignKey("candidate_id")]
        [Required(ErrorMessage = "Enter the Canidate Id")]
        public Int64 candidate_id { get; set; }
        [ForeignKey("location_id")]
        [Required(ErrorMessage = "Enter the Location Id")]
        public Int64 location_id { get; set; }
    }
}
