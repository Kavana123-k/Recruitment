 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class Owner
    {
        [Key]
        public Int64 id { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Firstname invalid")]
        public string first_name { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Lastname invalid")]
        public string last_name { get; set; }

    }
}
