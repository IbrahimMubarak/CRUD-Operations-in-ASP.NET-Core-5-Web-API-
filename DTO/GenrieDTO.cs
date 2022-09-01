﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.DTO
{
    public class GenrieDTO
    {
      
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
