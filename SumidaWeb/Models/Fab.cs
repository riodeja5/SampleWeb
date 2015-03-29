using System.Collections.Generic;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Fab
    {
        public int Id { get; set; }

        // 外部キーだけでなく、外部キーIDを追加しなければ、スキャフォールディング生成時にDropDownListを生成してくれない
        public virtual int? UserID { get; set; }

        [DisplayName("User名")]
        public virtual User User { get; set; }

        [DisplayName("Fab名称")]
        public string FabName { get; set; }

        public virtual ICollection<Workstation> Workstations { get; set; }
    }
}