using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Domain
{
    public class Album
    {
       // [DatabaseGenerated(DatabaseGeneratedOptions.Identity)]

        public int Id { get; set; }

        [Required]
        [MaxLength(60)]

        public string ProductName { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]

        public string VinylId { get; set; }

        public virtual Artist Vinyl { get; set; }

        public string Image { get; set; }

        [Required]
        [Range(0, 5000)]

        public int Quantity { get; set; }
        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
