﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Models.Genre
{
    public class GenrePairVM
    {
        public int Id { get; set; }

        [Display(Name = "Genre")]

        public string Name { get; set; }
    }
}
