using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Models.Artist;
using VinylWorld.Models.Genre;

namespace VinylWorld.Models.Album
{
    public class AlbumDetailsVM
    {  

        [Key]

        public int Id { get; set; }
        [Display(Name = "Album Name")]

        public string AlbumName { get; set; }

        public int ArtistId { get; set; }
        [Display(Name = "Artist")]

        public int ArtistName { get; set; }

        public int GenreId { get; set; }
        [Display(Name = "Genre")]

        public string GenreName { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]

        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
