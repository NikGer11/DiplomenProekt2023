using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Domain
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOptions.Identity)]

        public int Id { get; set; }

        [Required]

        public DateTime PurchaseDate { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal FinalPrice
        {
            get
            {
                return Quantity * Price - Quantity * Price * Discount / 100;
            }
        }
    }
}




