using System.Collections.Generic;

namespace MMA.FrontMVC.Models
{
    public class BaseIndexModel<T>
    {
        public List<T> Entities { get; set; } = new();
    }
}