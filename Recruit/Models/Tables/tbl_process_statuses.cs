using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class tbl_process_statuses
    {
        [Key]
        public Int64 id { get; set; }

        [StringLength(15)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "code invalid")]
        public string code { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "status invalid")]
        public string status { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string colour { get; set; }

    }
}
