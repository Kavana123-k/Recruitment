﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class tbl_employees
    {
        [Key]
        public string id { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is invalid")]
        public string name { get; set; }
    }
}
