using System.Data.Entity;
using MMA.Domain.Common;

namespace MMA.DAL.Common
{
    public class CommonContext : DbContext
    {
        public CommonContext() : base("DbConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}