using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMA.Domain.Common
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public uint Price { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public int CategoryId { get; set; }
    }
}
