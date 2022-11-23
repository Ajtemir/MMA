using System;
using System.Linq;
using MMA.Contract.Common;
using MMA.DAL.Common;

namespace ConsoleTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using var factory = new ServiceClientFactory<ICommonService>();
                
                var service = factory.GetService();
                Console.WriteLine(service.GetData(23));
                
                // var data = service.GetUser();
                var data = service.GetUsers().Entites.FirstOrDefault();
                
                // var connectionStr = "data source=127.0.0.1;User ID=login;Password=password;Initial Catalog=MMA;Integrated Security=True";
                // using var context = new CommonContext(connectionStr);
                // var data = context.Users.FirstOrDefault();

                Console.WriteLine(data!.PhoneNumber);
            
            // using (var context = new CommonContext())
            // {
            //     Console.WriteLine("start");
            //     Console.WriteLine(context.Users.First().PhoneNumber);
            // }
        }
    }
}