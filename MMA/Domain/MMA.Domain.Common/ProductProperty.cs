using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace MMA.Domain.Common
{
    [Table("ProductProperties",Schema = "dbo")]
    public class ProductProperty
    {
        [Key]
        [Column(Order = 0)]
        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ProductPropertyKeyId { get; set; }
        [ForeignKey(nameof(ProductPropertyKeyId))]
        public ProductPropertyKey ProductPropertyKey { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductPropertyValueId { get; set; }
        [ForeignKey(nameof(ProductPropertyValueId))]
        public ProductPropertyValue ProductPropertyValue { get; set; }

        public static ProductProperty CreateInstance(string str)
        {
            var array = str.Split('-').Select(x => Convert.ToInt32(x)).ToArray();
            return new ProductProperty
            {
                ProductId = array[0],
                ProductPropertyKeyId = array[1],
                ProductPropertyValueId = array[2]
            };
        }
    }
}
