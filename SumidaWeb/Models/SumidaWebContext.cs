using System.Data.Entity;

namespace SumidaWeb.Models
{
    public class SumidaWebContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        public DbSet<SOrder> SOrders { get; set; }
    }
}