using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Domain
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOptions.Identity)]

        public int Id { get; set; }

        [Required]

        public DateTime OrderDate { get; set; }

        [Required]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        [Required]

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]

        public int Quantity { get; set; }
        [Range(0, 5000)]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public decimal Discount { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price - Quantity * Price * Discount / 100;
            }
        }
    }
}




