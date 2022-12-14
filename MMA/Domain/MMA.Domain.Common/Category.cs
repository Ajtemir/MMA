using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MMA.Domain.Common
{
    [DataContract]
    [Table("Categories", Schema = "dbo")]
    public class Category
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } = default;
        [DataMember]
        [MaxLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [DataMember]
        public int? ParentCategoryId { get; set; }
        [IgnoreDataMember]
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
        
        [ForeignKey(nameof(CategoryId))]
        public ICollection<Category> SubCategories { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ICollection<ProductPropertyKey> ProductPropertyKeys { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ICollection<Product> Products { get; set; }
    }
}
