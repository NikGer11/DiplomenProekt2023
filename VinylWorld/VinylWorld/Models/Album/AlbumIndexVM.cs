using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Models.Album
{
    public class AlbumIndexVM
    {
        [Key]

        public int Id { get; set; }
        [Display(Name = "Album Name")]

        public string AlbumName { get; set; }

        public int ArtistId { get; set; }
        [Display(Name = "Artist")]

        public string ArtistName { get; set; }

        public int GenreId { get; set; }
        [Display(Name = " Genre")]

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
