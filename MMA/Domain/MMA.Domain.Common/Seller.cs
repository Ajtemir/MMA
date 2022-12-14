using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Data.Entity.Spatial;

namespace MMA.Domain.Common
{
    public class Seller
    {
        public int SellerId { get; set; }
        public int? ShopId { get; set; }
        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        [ForeignKey(nameof(SellerId))]
        // public ICollection<Product> Products { get; set; }
        public DbGeography Location { get; set; }

    }
}
