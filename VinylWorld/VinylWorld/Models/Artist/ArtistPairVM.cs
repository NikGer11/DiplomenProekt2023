using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Models.Artist
{
    public class ArtistPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Artist")]

        public string Name { get; set; }
    }
}
