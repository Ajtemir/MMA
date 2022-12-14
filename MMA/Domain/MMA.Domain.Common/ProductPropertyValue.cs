using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMA.Domain.Common
{
    [Table(nameof(ProductPropertyValue)+"s",Schema = "dbo")]
    public class ProductPropertyValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Идентификатор", AutoGenerateField = true)]
        public int ProductPropertyValueId { get; set; }
        [Required]
        [Display(Name = "Название значения свойства", AutoGenerateField = true)]
        public string ProductPropertyValueName { get; set; }
        [Display(Name = "Название ключа продукта", AutoGenerateField = true)]
        public int ProductPropertyKeyId { get; set; }
        [ForeignKey(nameof(ProductPropertyKeyId))]
        [Display(AutoGenerateField = false)]
        public ProductPropertyKey ProductPropertyKey { get; set; }
    }
}
