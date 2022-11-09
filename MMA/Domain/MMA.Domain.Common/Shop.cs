using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Text;

namespace MMA.Domain.Common
{
    public class Shop
    {
        public int ShopId { get; set; }
        public int? MarketId { get; set; }
        public Market Market { get; set; }
        public DbGeography Location { get; set; }
    }
}
