using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Models.Artist;
using VinylWorld.Models.Genre;

namespace VinylWorld.Models.Album
{
    public class AlbumEditVM
    {
        public AlbumEditVM()
        {
            Artists = new List<ArtistPairVM>();
            Genres = new List<GenrePairVM>();
        }

        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Album Name")]

        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Artist")]

        public int ArtistId { get; set; }

        public virtual List<ArtistPairVM> Artists { get; set; }

        [Required]
        [Display(Name = "Genre")]

        public int GenreId { get; set; }

        public virtual List<GenrePairVM> Genres { get; set; }

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

