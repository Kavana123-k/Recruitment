using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class Source
    {
        [Key]
        public Int64 id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Source code is invalid")]
        public string code { get; set; }
        [StringLength(25)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Source Name is invalid")]
        public string name { get; set; }

    }
}
