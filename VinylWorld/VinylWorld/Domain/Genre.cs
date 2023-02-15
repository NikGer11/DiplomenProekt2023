using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]

        public string GenreName { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; } = new List<Album>();

    }
}
