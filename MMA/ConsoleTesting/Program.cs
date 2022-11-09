using System;
using System.Linq;
using MMA.DAL.Common;

namespace ConsoleTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new CommonContext())
            {
                Console.WriteLine("start");
                Console.WriteLine(context.Users.First().PhoneNumber);
            }
        }
    }
}