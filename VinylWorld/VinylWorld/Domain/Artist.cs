using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Domain
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]

        public string ArtistName { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; } = new List<Album>();
    }
}
