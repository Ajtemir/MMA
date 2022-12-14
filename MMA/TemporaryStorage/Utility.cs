using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TemporaryStorage
{
    public static class Utility
    {
        public static List<string> GetGridHeaders<T>()
        {
            var properties = typeof(T).GetProperties();
            var attributes = properties.Select(x => (DisplayAttribute)x.GetCustomAttribute(typeof(DisplayAttribute)));
            var rendered = attributes.Where(x => x.AutoGenerateField).Select(x => x.Name);
            return rendered.ToList();
        }
    }
}