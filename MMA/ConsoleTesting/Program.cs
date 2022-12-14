using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using MMA.Contract.Common;
using MMA.DAL.Common;
using MMA.Domain.Common;

namespace ConsoleTesting
{
    internal class Program
    {
        public static List<string> GetGridHeaders<T>()
        {
            var properties = typeof(T).GetProperties();
            var attributes = properties.Select(x => (DisplayAttribute)x.GetCustomAttribute(typeof(DisplayAttribute)));
            var rendered = attributes.Where(x => x.AutoGenerateField).Select(x => x.Name);
            return rendered.ToList();
        }

        public static void Main(string[] args)
        {
            // var result = typeof(ProductPropertyValue).GetProperties().FirstOrDefault();
            // var attribute = result.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            // Console.WriteLine(attribute.Name);
            // Console.WriteLine((DisplayAttribute)result.GetCustomAttribute(typeof(DisplayAttribute)));
            // return;
            var headers = GetGridHeaders<ProductPropertyValue>();
            headers.ForEach(Console.WriteLine);
            // var type = typeof(ProductPropertyValue);
            // var entity = new ProductPropertyValue
            // {
            //     ProductPropertyValueId = 432
            // };
            // var properties = entity.GetType().GetProperties().ToList();
            // var propertyInfo = properties.First();
            // Console.WriteLine(propertyInfo.GetValue(entity));
            // object customAttribute = propertyInfo.CustomAttributes.First();
            // // var customAttributes = entity.GetType().GetCustomAttributes();
            // var attribute = customAttribute as DisplayAttribute;
            // Console.WriteLine(propertyInfo.Name);
            // foreach (var customAttribute in propertyInfo.CustomAttributes)
            // {
            //     Console.WriteLine(customAttribute.GetType().GetProperty(nameof(customAttribute)).GetValue(entity,null));
            // }
            // foreach (var propertyInfo in properties)
            // {
            //     Console.WriteLine(propertyInfo.Name);   
            // }
            // using var factory = new ServiceClientFactory<ICommonService>();
            //     
            //     var service = factory.GetService();
            //     Console.WriteLine(service.GetData(23));

            // var data = service.GetUser();
            // var data = service.GetUsers().Results.FirstOrDefault();

            // var connectionStr = "data source=127.0.0.1;User ID=login;Password=password;Initial Catalog=MMA;Integrated Security=True";
            // using var context = new CommonContext(connectionStr);
            // var data = context.Users.FirstOrDefault();

            // Console.WriteLine(data!.PhoneNumber);

            // using (var context = new CommonContext())
            // {
            //     Console.WriteLine("start");
            //     Console.WriteLine(context.Users.First().PhoneNumber);
            // }
        }
    }
}