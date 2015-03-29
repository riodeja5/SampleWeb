using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Fab
    {
        public int Id { get; set; }

        [DisplayName("User")]
        public virtual User User { get; set; }

        [DisplayName("Fab名称")]
        public string FabName { get; set; }
    }
}