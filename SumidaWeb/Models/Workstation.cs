using System;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Workstation
    {
        public int Id { get; set; }

        public virtual Fab Fab { get; set; }

        public virtual Machine Machnie { get; set; }

        [DisplayName("装置番号")]
        public int EquipmentNo { get; set; }

        [DisplayName("MACアドレス")]
        public string MapAddress { get; set; }

        [DisplayName("備考")]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("緊急用MACアドレス")]
        public string EmargencyMapAddress { get; set; }
    }
}