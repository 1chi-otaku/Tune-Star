﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tune_Star.BLL.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string? Name { get; set; }
    }
}
