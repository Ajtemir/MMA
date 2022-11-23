using System.Configuration;
using System.Data.Entity;
using MMA.Domain.Common;

namespace MMA.DAL.Common
{
    public class CommonContext : DbContext
    {
        public CommonContext(string connectionString) : base(connectionString)
        {
        }

        public CommonContext() : base("DbConnection")
        {
            Database.Connection.Open();
        }

        
        public DbSet<User> Users { get; set; }
    }
}