using System.Data.Entity;

namespace SumidaWeb.Models
{
    public class SumidaWebContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SOrder> SOrders { get; set; }

        public System.Data.Entity.DbSet<SumidaWeb.Models.Roll> Rolls { get; set; }

        public System.Data.Entity.DbSet<SumidaWeb.Models.Machine> Machines { get; set; }

        public System.Data.Entity.DbSet<SumidaWeb.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<SumidaWeb.Models.Fab> Fabs { get; set; }

        public System.Data.Entity.DbSet<SumidaWeb.Models.Workstation> Workstations { get; set; }
    }
}