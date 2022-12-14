using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMA.Domain.Common
{
    [Table("ProductPropertyKeys",Schema = "dbo")]
    public class ProductPropertyKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductPropertyKeyId { get; set; }
        public string ProductPropertyKeyName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public bool IsMultiple { get; set; }
        public ICollection<ProductPropertyValue> PropertyValues { get; set; }
    }
}
