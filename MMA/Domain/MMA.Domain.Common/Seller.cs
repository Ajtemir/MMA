using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Spatial;

namespace MMA.Domain.Common
{
    public class Seller
    {
        public int SellerId { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
        public DbGeography Location { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
