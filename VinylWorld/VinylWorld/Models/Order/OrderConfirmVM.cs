using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinylWorld.Models.Order
{
    public class OrderConfirmVM
    {
        [Key]

        public int Id { get; set; }
        [Required]

        public string UserId { get; set; }

        public string User { get; set; }
        [Required]

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public string Picture { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
