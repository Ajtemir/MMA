using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMA.Domain.Common
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        public ICollection<ProductProperty> ProductProperties { get; set; }
        
        // public int SellerId { get; set; }
        // [ForeignKey(nameof(SellerId))]
        // public Seller Seller { get; set; }
    }
}
