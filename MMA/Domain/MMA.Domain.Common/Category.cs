using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMA.Domain.Common
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int Name { get; set; }
        public int ParentCategory { get; set; }
        public bool IsLowest => !SubCategories.Any();
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Category> LowestSubCategories { get; set; }
        public ICollection<PropertyKey> PropertyKeys { get; set; }
    }
}
