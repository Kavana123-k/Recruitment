﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Models
{
    public class Location
    {
        [Key]
        public Int64 id { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "City is invalid")]
        public string city { get; set; }
    }
}
