using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Machine
    {
        public int Id { get; set; }

        [DisplayName("機種")]
        public string MachineType { get; set; }
    }
}