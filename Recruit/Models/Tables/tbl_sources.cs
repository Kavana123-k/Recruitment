using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class tbl_sources
    {
        [Key]
        public string code { get; set; }
        [StringLength(15)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Source Name is invalid")]
        public string name { get; set; }

    }
}
