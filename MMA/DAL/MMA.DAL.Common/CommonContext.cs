using System.Configuration;
using System.Data.Entity;
using MMA.Domain.Common;

namespace MMA.DAL.Common
{
    public class CommonContext : DbContext
    {
        public CommonContext(string connectionString) : base(connectionString)
        {
            Database.Connection.Open();
        }

        private static string ConnectionString = "MultipleActiveResultSets=False;data source=localhost;Initial Catalog=MMA;User ID=login;Password=password;Integrated Security=True";
        public CommonContext(bool fromConfig = false) : base(fromConfig ? "DbConnection" : ConnectionString)
        {
            Database.Connection.Open();
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPropertyKey> ProductPropertyKeys { get; set; }
        public DbSet<ProductPropertyValue> ProductPropertyValues { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
    }
}