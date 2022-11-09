using System;
using System.Collections.Generic;
using System.Text;

namespace MMA.Domain.Common
{
    public class PropertyKey
    {
        public int PropertyKeyId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public ICollection<PropertyValue> PropertyValues { get; set; }
    }
}
