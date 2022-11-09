using System;
using System.Collections.Generic;
using System.Text;

namespace MMA.Domain.Common
{
    public class ProductProperty
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PropertyKeyId { get; set; }
        public PropertyKey PropertyKey { get; set; }
        public int PropertyValueId { get; set; }
        public PropertyValue PropertyValue { get; set; }
    }
}
