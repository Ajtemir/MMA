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
            using var service = new ServiceClientFactory<ICommonService>();
            
                var data = service.GetService().GetData(5);
                Console.WriteLine(data);
            
            // using (var context = new CommonContext())
            // {
            //     Console.WriteLine("start");
            //     Console.WriteLine(context.Users.First().PhoneNumber);
            // }
        }
    }
}