using System;
using System.Collections.Generic;
using System.Text;

namespace MMA.Domain.Common
{
    public class PropertyValue
    {
        public int PropertyValueId { get; set; }
        public string Name { get; set; }
        public int PropertyKeyId { get; set; }
        public PropertyKey PropertyKey { get; set; }
    }
}
